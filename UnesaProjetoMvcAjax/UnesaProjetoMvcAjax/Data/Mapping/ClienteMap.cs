using System.Data.Entity.ModelConfiguration;
using UnesaProjetoMvcAjax.Models;

namespace UnesaProjetoMvcAjax.Data.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");

            HasKey(p => p.Id);

            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(15)
                .IsRequired();

            Property(p => p.Telefone)
                .HasColumnName("Telefone")
                .HasMaxLength(15)
                .IsRequired();

            Property(p => p.Email)
                .HasColumnName("E-mail")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}