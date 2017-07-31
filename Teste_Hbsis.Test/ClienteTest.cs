using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Infra;
using Teste_Hbsis.Infra.Repositories;

namespace Teste_Hbsis.Test
{
    [TestClass]
    public class ClienteTest : BaseTest
    {
        /// <summary>
        /// Testa um crud do repository
        /// </summary>
        [TestMethod]
        public void TestClienteCrudRepository()
        {
            int codigoCliente = 999999; //Um codigo que nao vai ser utilizado em qa.
            //Cria um cliente fake
            RepositoryCliente.Add(new Domain.Entities.Cliente()
            {
                Codigo = codigoCliente,
                Documento = "37604089828",
                Nome = "Daniel Ladislau Wozniak",
                Telefone = "19994615704"
            });
            //Verifica se ele existe
            Assert.IsTrue(RepositoryCliente.Exists(codigoCliente));
            var cliente = RepositoryCliente.GetCliente(codigoCliente);
            Assert.IsNotNull(cliente);
            //Deleta o cliente
            RepositoryCliente.Delete(cliente);
            //Verifica se realmente foi removido do banco
            Assert.IsFalse(RepositoryCliente.Exists(codigoCliente));
        }

        /// <summary>
        /// Testa um crud no Service
        /// </summary>
        [TestMethod]
        public void TestClienteCrudService()
        {
            //Pega o codigo do novo cliente
            int codigoCliente = RepositoryCliente.GetCodigo();
            //Insere um novo cliente
            ServiceCliente.Add(new Domain.Models.ClienteModel()
            {
                Codigo = codigoCliente,
                Documento = "37604089821",
                Nome = "Daniel Teste",
                Telefone = "1932450892"
            });
            //Pega o cliente pelo codigo
            var cliente = ServiceCliente.GetCliente(codigoCliente);
            //Efetua as validacoes
            Assert.IsNotNull(cliente);
            Assert.IsFalse(cliente.Error);
            Assert.IsNotNull(cliente.Return);

            Assert.AreEqual("37604089821", cliente.Return.Documento);
            Assert.AreEqual("Daniel Teste", cliente.Return.Nome);
            Assert.AreEqual("1932450892", cliente.Return.Telefone);
            Assert.IsFalse(cliente.Return.Excluido);

            //Altera os dados do cliente
            cliente.Return.Documento = "1111111111";
            cliente.Return.Nome = "ABC123";
            cliente.Return.Telefone = "1111111";
            //Atualiza o cliente
            ServiceCliente.Update(cliente.Return);
            
            //Pega novamente o cliente e verifica os dados
            cliente = ServiceCliente.GetCliente(codigoCliente);
            Assert.IsNotNull(cliente);
            Assert.IsNotNull(cliente.Return);
            Assert.IsFalse(cliente.Error);

            Assert.AreEqual("1111111111", cliente.Return.Documento);
            Assert.AreEqual("ABC123", cliente.Return.Nome);
            Assert.AreEqual("1111111", cliente.Return.Telefone);

            //Deleta o cliente (Somente com a flag)
            ServiceCliente.Delete(codigoCliente);
            //Pega o cliente para verificar se o flag esta como excluido.
            cliente = ServiceCliente.GetCliente(codigoCliente);
            Assert.IsNotNull(cliente);
            Assert.IsNotNull(cliente.Return);
            Assert.IsFalse(cliente.Error);
            Assert.IsTrue(cliente.Return.Excluido);

            //Remove realmente o cliente do banco.
            var clienteToRemove = RepositoryCliente.GetCliente(codigoCliente);
            Assert.IsNotNull(clienteToRemove);
            RepositoryCliente.Delete(clienteToRemove);
        }

    }
}
