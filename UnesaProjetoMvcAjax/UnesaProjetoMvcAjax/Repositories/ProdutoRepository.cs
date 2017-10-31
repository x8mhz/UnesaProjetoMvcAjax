using System.Data.Entity;
using System.Linq;
using UnesaProjetoMvcAjax.Data.Context;
using UnesaProjetoMvcAjax.Models;
using UnesaProjetoMvcAjax.Repositories.Contracts;

namespace UnesaProjetoMvcAjax.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly UnesaProjetoMvcAjaxContext _context;

        public ProdutoRepository(UnesaProjetoMvcAjaxContext context)
        {
            _context = context;
        }

        public IQueryable<Produto> GetAll()
        {
            return _context.Produtos;
        }

        public Produto GetById(int? id)
        {
            return _context.Produtos.Find(id);
        }

        public IQueryable<Produto> GetByCategoria(string categoria)
        {
            return _context.Set<Produto>().Where(p => p.Categoria == categoria);
        }

        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Edit(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
        }

        public void Remove(Produto produto)
        {
            _context.Produtos.Remove(produto);
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