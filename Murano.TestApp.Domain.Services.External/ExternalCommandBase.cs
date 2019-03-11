using Murano.TestApp.Data.Repositories;
using Murano.TestApp.Infrastructure.IoC;
using Murano.TestApp.Infrastructure.Services;
using Murano.TestApp.Infrastructure.Services.Commands;
using Murano.TestApp.Infrastructure.Services.Requests;
using Murano.TestApp.Infrastructure.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External
{
    public abstract class ExternalCommandBase<TRequest, TResponse> :
        IExternalCommand<TRequest, TResponse>
        where TRequest : class, IRequest
        where TResponse : Response, new()
    {
        protected virtual bool RequireTransaction { get { return false; } }

        protected virtual TRequest Request { get; private set; }

        protected virtual TResponse Response { get; private set; }

        public virtual TResponse Execute(TRequest externalRequest, CancellationToken cancellationToken)
        {

                Request = externalRequest;

                try
                {
                    UnitOfWork = IoC.Resolve<IUnitOfWork>();

                    if (!Authenticate())
                    {
                        return ErrorResponse(new Error(CommonErrorCode.UserNotAuthenticated));
                    }

                    LimitDbContext(UnitOfWork.DbContext);

                    if (RequireTransaction)
                    {
                        UnitOfWork.BeginTransaction();
                    }

                    try
                    {
                        Response = ExecuteInternal(Request);

                        UnitOfWork.SaveChanges();

                        if (RequireTransaction)
                        {
                            UnitOfWork.CompleteTransaction();
                        }
                    }
                    catch (Exception e)
                    {
                        if (RequireTransaction)
                        {
                            UnitOfWork.RollbackTransaction();
                        }

                        //ErrorLogUtils.AddError(e);

                        return ErrorResponse(new Error(CommonErrorCode.InternalServerError),
                            extraMessage: e.Message + Environment.NewLine + e.StackTrace);
                    }
                }
                catch (Exception e)
                {
                    //ErrorLogUtils.AddError(e);

                    return ErrorResponse(new Error(CommonErrorCode.InternalServerError),
                        extraMessage: e.Message + Environment.NewLine + e.StackTrace);
                }
                finally
                {
                    if (UnitOfWork != null)
                        UnitOfWork.Dispose();
                }

                return Response;
        }

        protected abstract void LimitDbContext(IDbContext dbContext);

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected abstract TResponse ExecuteInternal(TRequest request);

        protected abstract bool Authenticate();

        protected TResponse ErrorResponse(Error error, ArgumentErrorsCollection argumentErrors = null,
            string extraMessage = null)
        {
            Response.IsSuccess = false;

            Response.Error = error;

            if (argumentErrors != null)
            {
                foreach (var argumentError in argumentErrors)
                {
                    Response.ArgumentErrors[argumentError.ArgumentName] = argumentError;
                }
            }

            if (extraMessage != null)
                Response.Error.ErrorMessage += Environment.NewLine + extraMessage;

            return Response;
        }
    }
}
