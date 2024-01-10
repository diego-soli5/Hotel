using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.DataAccess.Configurations
{
    public class ThtClienteConfigurations : IEntityTypeConfiguration<ThtCliente>
    {
        public void Configure(EntityTypeBuilder<ThtCliente> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_Cliente");

            builder.ToTable("THT_CLIENTE");

            builder.Property(e => e.Id).HasColumnName("TN_IdCliente");
            builder.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            builder.Property(e => e.TcAp1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Ap1");
            builder.Property(e => e.TcAp2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Ap2");
            builder.Property(e => e.TcCorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_CorreoElectronico");
            builder.Property(e => e.TcNombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Nombre");
            builder.Property(e => e.TcNumTelefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TC_NumTelefono");
        }
    }
}
