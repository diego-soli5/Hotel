using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.DataAccess.Configurations
{
    public class ThtDetallehabitacionConfigurations : IEntityTypeConfiguration<ThtDetallehabitacion>
    {
        public void Configure(EntityTypeBuilder<ThtDetallehabitacion> builder)
        {
            builder.HasKey(e => e.TnIdHabitacion).HasName("PK__THT_DETA__F0673EA3A6926C8B");

            builder.ToTable("THT_DETALLEHABITACION");

            builder.Property(e => e.TnIdHabitacion)
                .ValueGeneratedNever()
                .HasColumnName("TN_IdHabitacion");
            builder.Property(e => e.TcDscAmenidades)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TC_DscAmenidades");
            builder.Property(e => e.TcTamanoHabitacion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_TamanoHabitacion");

            builder.HasOne(d => d.TnIdHabitacionNavigation).WithOne(p => p.ThtDetallehabitacionNavigation)
                .HasForeignKey<ThtDetallehabitacion>(d => d.TnIdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__THT_DETAL__TN_Id__2E1BDC42");
        }
    }
}
