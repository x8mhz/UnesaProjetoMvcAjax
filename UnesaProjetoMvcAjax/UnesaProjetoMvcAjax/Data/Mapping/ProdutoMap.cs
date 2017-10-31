using System.Data.Entity.ModelConfiguration;
using UnesaProjetoMvcAjax.Models;

namespace UnesaProjetoMvcAjax.Data.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(p => p.Id);

            Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .IsRequired();

            Property(p => p.Categoria)
                .HasColumnName("Categoria")
                .IsRequired();

            Property(p => p.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            Property(p => p.Valor)
                .HasColumnName("Preco")
                .IsRequired();
        }
    }
}