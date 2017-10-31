using System.Linq;
using UnesaProjetoMvcAjax.Models;

namespace UnesaProjetoMvcAjax.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        IQueryable<Produto> GetAll();
        Produto GetById(int? id);
        IQueryable<Produto> GetByCategoria(string categoria);
        void Add(Produto produto);
        void Edit(Produto produto);
        void Remove(Produto produto);
        void Save();
        void Dispose();
    }
}