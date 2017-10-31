using System.Data.Entity;
using System.Linq;
using UnesaProjetoMvcAjax.Data.Context;
using UnesaProjetoMvcAjax.Models;
using UnesaProjetoMvcAjax.Repositories.Contracts;

namespace UnesaProjetoMvcAjax.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly UnesaProjetoMvcAjaxContext _context;

        public ClienteRepository(UnesaProjetoMvcAjaxContext context)
        {
            _context = context;
        }

        public IQueryable<Cliente> GetAll()
        {
            return _context.Clientes;
        }

        public Cliente GetById(int? id)
        {
            return _context.Clientes.Find(id);
        }

        public Cliente GetByCpf(string cpf)
        {
            return _context.Set<Cliente>().SingleOrDefault(p => p.Cpf == cpf);
        }

        public IQueryable<Cliente> GetByNome(string nome)
        {
            return _context.Set<Cliente>().Where(p => p.Nome == nome);
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Edit(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
        }

        public void Remove(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}