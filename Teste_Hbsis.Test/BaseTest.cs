using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Domain.Interfaces.IRepositories;
using Teste_Hbsis.Domain.Interfaces.IServices;

namespace Teste_Hbsis.Test
{
    public class BaseTest
    {
        public Container Container { get; set; }
        public IRepositoryCliente RepositoryCliente { get; set; }

        public IServiceCliente ServiceCliente { get; set; }

        public BaseTest()
        {
            RegisterSimpleInjectClass();

            RepositoryCliente = Container.GetInstance<IRepositoryCliente>();
            ServiceCliente = Container.GetInstance<IServiceCliente>();
        }

        public void RegisterSimpleInjectClass()
        {
            Ioc.Registry.Initialize();
            Container = Ioc.Registry.Container;
        }
    }
}
