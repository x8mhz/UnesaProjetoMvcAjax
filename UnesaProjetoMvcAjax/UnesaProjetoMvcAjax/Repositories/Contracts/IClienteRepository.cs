using System.Linq;
using UnesaProjetoMvcAjax.Models;

namespace UnesaProjetoMvcAjax.Repositories.Contracts
{
    public interface IClienteRepository
    {
        IQueryable<Cliente> GetAll();
        Cliente GetById(int? id);
        Cliente GetByCpf(string cpf);
        IQueryable<Cliente> GetByNome(string nome);
        void Add(Cliente aluno);
        void Edit(Cliente aluno);
        void Remove(Cliente aluno);
        void Save();
        void Dispose();
    }
}