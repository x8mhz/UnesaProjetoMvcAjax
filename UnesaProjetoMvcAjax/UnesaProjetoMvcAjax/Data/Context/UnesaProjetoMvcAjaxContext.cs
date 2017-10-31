using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UnesaProjetoMvcAjax.Data.Mapping;
using UnesaProjetoMvcAjax.Models;

namespace UnesaProjetoMvcAjax.Data.Context
{
    public class UnesaProjetoMvcAjaxContext : DbContext
    {
        public UnesaProjetoMvcAjaxContext()
            : base("UnesaProjetoMvcAjaxContext")
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
        }
    }
}