using Hbsis_Teste.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste_Hbsis.Domain.Interfaces.IServices;
using Teste_Hbsis.Domain.Models;

namespace Teste_Hbsis.WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        private IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        /// <summary>
        /// Metodo que retorna lista de clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Result<List<ClienteModel>> GetClientes()
        {
            var result = new Result<List<ClienteModel>>();
            try
            {
                result = _serviceCliente.GetClientes();
            }
            catch(Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Metodo que retorna cliente.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet]
        public Result<ClienteModel> GetCliente(int codigo)
        {
            var result = new Result<ClienteModel>();
            try
            {
                result = _serviceCliente.GetCliente(codigo);
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Metodo que adiciona um cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public Result<bool> AddCliente(ClienteModel cliente)
        {
            var result = new Result<bool>();
            try
            {
                result = _serviceCliente.Add(cliente);
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Metodo que atualiza o cliente.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost]
        public Result<bool> UpdateCliente(ClienteModel cliente)
        {
            var result = new Result<bool>();
            try
            {
                result = _serviceCliente.Update(cliente);
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// Metodo que deleta cliente.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpPost]
        public Result<bool> DeleteCliente(int codigo)
        {
            var result = new Result<bool>();
            try
            {
                result = _serviceCliente.Delete(codigo);
            }
            catch (Exception ex)
            {
                result.Error = true;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
