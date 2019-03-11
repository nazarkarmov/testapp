using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Murano.TestApp.Infrastructure.IoC
{
    public class IoC
    {
        private static readonly Lazy<IUnityContainer> LazyContainer = new Lazy<IUnityContainer>(() => new UnityContainer());

        public static IUnityContainer Container
        {
            get { return LazyContainer.Value; }
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static T Resolve<T>(string name)
        {
            return Container.Resolve<T>(name);
        }
    }
}
