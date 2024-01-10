using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.DataAccess.Configurations
{
    public class ThtReservacionConfigurations : IEntityTypeConfiguration<ThtReservacion>
    {
        public void Configure(EntityTypeBuilder<ThtReservacion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__THT_RESE__46A5B8DC05276731");

            builder.ToTable("THT_RESERVACION");

            builder.Property(e => e.Id).HasColumnName("TN_NumReservacion");
            builder.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            builder.Property(e => e.TfFecFin)
                .HasColumnType("datetime")
                .HasColumnName("TF_FecFin");
            builder.Property(e => e.TfFecInicio)
                .HasColumnType("datetime")
                .HasColumnName("TF_FecInicio");
            builder.Property(e => e.TnIdCliente).HasColumnName("TN_IdCliente");
            builder.Property(e => e.TnIdHabitacion).HasColumnName("TN_IdHabitacion");

            builder.HasOne(d => d.TnIdClienteNavigation).WithMany(p => p.ThtReservacion)
                .HasForeignKey(d => d.TnIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__THT_RESER__TN_Id__30F848ED");

            builder.HasOne(d => d.TnIdHabitacionNavigation).WithMany(p => p.ThtReservacions)
                .HasForeignKey(d => d.TnIdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__THT_RESER__TN_Id__300424B4");
        }
    }
}
