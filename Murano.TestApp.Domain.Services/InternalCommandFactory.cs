using Murano.TestApp.Infrastructure.IoC;
using Murano.TestApp.Infrastructure.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;


namespace Murano.TestApp.Domain.Services
{
    public class InternalCommandFactory
    {
        public virtual TCommand Create<TCommand>()
            where TCommand : IInternalCommand
        {
            return IoC.Container.Resolve<TCommand>();
        }
    }
}
