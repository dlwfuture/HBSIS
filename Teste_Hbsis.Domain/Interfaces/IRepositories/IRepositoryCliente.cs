using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Domain.Entities;

namespace Teste_Hbsis.Domain.Interfaces.IRepositories
{
    public interface IRepositoryCliente
    {
        List<Cliente> GetClientes();
        Cliente GetCliente(int codigo);
        void Add(Cliente cliente);
        int GetCodigo();
        void Update(Cliente cliente);
        bool Exists(int codigo);
        void Delete(Cliente cliente);
    }
}
