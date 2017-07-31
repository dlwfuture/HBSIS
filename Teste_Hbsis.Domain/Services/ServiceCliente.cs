using Hbsis_Teste.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Domain.Entities;
using Teste_Hbsis.Domain.Interfaces.IRepositories;
using Teste_Hbsis.Domain.Interfaces.IServices;
using Teste_Hbsis.Domain.Models;

namespace Teste_Hbsis.Domain.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private IRepositoryCliente _repositoryCliente;
        public ServiceCliente(IRepositoryCliente repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        public Result<List<ClienteModel>> GetClientes()
        {
            var result = new Result<List<ClienteModel>>();
            try
            {
                result.Return = _repositoryCliente.GetClientes()
                    .Select(c => EntityToModel(c))
                    .ToList();
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<ClienteModel> GetCliente(int codigo)
        {
            var result = new Result<ClienteModel>();
            try
            {
                result.Return = EntityToModel(_repositoryCliente.GetCliente(codigo));
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<bool> Add(ClienteModel cliente)
        {
            var result = new Result<bool>();
            try
            {
                cliente.Codigo = _repositoryCliente.GetCodigo();
                _repositoryCliente.Add(ModelToEntity(cliente));
                result.Message = "Cliente cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<bool> Update(ClienteModel cliente)
        {
            var result = new Result<bool>();
            try
            {
                var model = _repositoryCliente.GetCliente(cliente.Codigo);
                if (model == null)
                {
                    result.Error = true;
                    result.Message = "Cliente não encontrado.";
                    return result;
                }
                model.Documento = cliente.Documento;
                model.Excluido = cliente.Excluido;
                model.Nome = cliente.Nome;
                model.Telefone = cliente.Telefone;
                _repositoryCliente.Update(model);
                result.Message = "Cliente atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<bool> Delete(int codigo)
        {
            var result = new Result<bool>();
            try
            {
                var model = _repositoryCliente.GetCliente(codigo);
                if (model == null)
                {
                    result.Error = true;
                    result.Message = "Cliente não encontrado.";
                    return result;
                }
                model.Excluido = true;
                _repositoryCliente.Update(model);
                result.Message = "Cliente removido com sucesso.";
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }

        private ClienteModel EntityToModel(Cliente cliente)
        {
            return cliente == null ? new ClienteModel() : new ClienteModel() {
                Codigo = cliente.Codigo,
                Documento = cliente.Documento,
                Telefone = cliente.Telefone,
                Excluido = cliente.Excluido,
                Nome = cliente.Nome,
                IsCpf = cliente.IsCpf
            };
        }

        private Cliente ModelToEntity(ClienteModel cliente)
        {
            return cliente == null ? new Cliente() : new Cliente()
            {
                Codigo = cliente.Codigo,
                Documento = cliente.Documento,
                Telefone = cliente.Telefone,
                Excluido = cliente.Excluido,
                Nome = cliente.Nome,
                IsCpf = cliente.IsCpf
            };
        }
    }
}
