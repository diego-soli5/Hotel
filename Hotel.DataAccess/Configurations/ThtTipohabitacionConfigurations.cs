using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.DataAccess.Configurations
{
    public class ThtTipohabitacionConfigurations : IEntityTypeConfiguration<ThtTipohabitacion>
    {
        public void Configure(EntityTypeBuilder<ThtTipohabitacion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK_TipoHabitacion");

            builder.ToTable("THT_TIPOHABITACION");

            builder.Property(e => e.Id).HasColumnName("TN_IdTipoHabitacion");
            builder.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            builder.Property(e => e.TcNomTipoHabitacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_NomTipoHabitacion");
        }
    }
}
