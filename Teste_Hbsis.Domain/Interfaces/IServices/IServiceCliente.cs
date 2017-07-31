using Hbsis_Teste.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Domain.Models;

namespace Teste_Hbsis.Domain.Interfaces.IServices
{
    public interface IServiceCliente
    {
        Result<List<ClienteModel>> GetClientes();
        Result<ClienteModel> GetCliente(int codigo);
        Result<bool> Add(ClienteModel cliente);
        Result<bool> Update(ClienteModel cliente);
        Result<bool> Delete(int codigo);
    }
}
