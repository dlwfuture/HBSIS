using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Hbsis.Domain.Entities;
using Teste_Hbsis.Domain.Interfaces;
using Teste_Hbsis.Domain.Interfaces.IRepositories;

namespace Teste_Hbsis.Infra.Repositories
{
    public class RepositoryCliente : IRepositoryCliente
    {
        private EntityContext _context;
        public RepositoryCliente(IDbContext context)
        {
            _context = (EntityContext)context;
        }

        public List<Cliente> GetClientes()
        {
            return _context.Cliente.Where(c => !c.Excluido).ToList();
        }

        public Cliente GetCliente(int codigo)
        {
            return _context.Cliente.FirstOrDefault(c => c.Codigo == codigo);
        }
        public void Add(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public int GetCodigo()
        {
            return _context.Cliente.Select(c => c.Codigo).DefaultIfEmpty().Max() + 1;
        }
        public void Update(Cliente cliente)
        {
            _context.Entry(cliente);
            _context.SaveChanges();
        }
        public bool Exists(int codigo)
        {
            return _context.Cliente.Any(c => c.Codigo == codigo);
        }
        public void Delete(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
