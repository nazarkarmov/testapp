using Murano.TestApp.Infrastructure.IoC;
using Murano.TestApp.Infrastructure.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murano.TestApp.Domain.Services.External
{
    public class ExternalCommandFactory
    {
        public virtual TCommand Create<TCommand>() where TCommand : IExternalCommand
        {
            var command = IoC.Resolve<TCommand>();
            return command;
        }
    }
}
