using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.DataAccess.Configurations
{
    public class ThtHabitacionConfigurations : IEntityTypeConfiguration<ThtHabitacion>
    {
        public void Configure(EntityTypeBuilder<ThtHabitacion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__THT_HABI__F0673EA36A60B2AB");

            builder.ToTable("THT_HABITACION");

            builder.Property(e => e.Id).HasColumnName("TN_IdHabitacion");
            builder.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            builder.Property(e => e.TcDscHabitacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TC_DscHabitacion");
            builder.Property(e => e.TcNombreHabitacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_NombreHabitacion");
            builder.Property(e => e.TdPrecioXnoche)
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("TD_PrecioXNoche");
            builder.Property(e => e.TnIdTipoHabitacion).HasColumnName("TN_IdTipoHabitacion");

            builder.HasOne(d => d.TnIdTipoHabitacionNavigation).WithMany(p => p.ThtHabitacions)
                .HasForeignKey(d => d.TnIdTipoHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__THT_HABIT__TN_Id__2E1BDC42");
        }
    }
}
