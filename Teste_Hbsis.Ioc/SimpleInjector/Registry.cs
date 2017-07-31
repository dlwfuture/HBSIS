using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Domain.Interfaces;
using Teste_Hbsis.Domain.Interfaces.IRepositories;
using Teste_Hbsis.Domain.Interfaces.IServices;
using Teste_Hbsis.Domain.Services;
using Teste_Hbsis.Infra;
using Teste_Hbsis.Infra.Repositories;

namespace Teste_Hbsis.Ioc
{
    public class Registry
    {
        public static Container Container { get; set; }

        public static void Initialize()
        {
            Container = new Container();
            Container.Register<IDbContext, EntityContext>();
            Container.Register<IRepositoryCliente, RepositoryCliente>();
            Container.Register<IServiceCliente, ServiceCliente>();

        }
    }
}
