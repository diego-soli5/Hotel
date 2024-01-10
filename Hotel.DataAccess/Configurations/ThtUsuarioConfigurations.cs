using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.DataAccess.Configurations
{
    public class ThtUsuarioConfigurations : IEntityTypeConfiguration<ThtUsuario>
    {
        public void Configure(EntityTypeBuilder<ThtUsuario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__THT_USUA__1182D56D1D87CC28");

            builder.ToTable("THT_USUARIO");

            builder.Property(e => e.Id).HasColumnName("TN_IdUsuario");
            builder.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            builder.Property(e => e.TcClave)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TC_Clave");
            builder.Property(e => e.TcCorreo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_Correo");
            builder.Property(e => e.TcNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TC_Nombre");
            builder.Property(e => e.TcNombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TC_NombreUsuario");
        }
    }
}
