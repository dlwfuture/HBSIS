using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste_Hbsis.WebApi.App_Start
{
    public static class SimpleConfig
    {
        public static System.Web.Http.Dependencies.IDependencyResolver Register()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Ioc.Registry.Initialize();
            container = Ioc.Registry.Container;

            return new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}