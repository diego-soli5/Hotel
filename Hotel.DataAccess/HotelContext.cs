using System;
using System.Collections.Generic;
using System.Reflection;
using Hotel.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataAccess;

public partial class HotelContext : DbContext
{
    public HotelContext()
    {
    }

    public HotelContext(DbContextOptions<HotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ThtCliente> ThtCliente { get; set; }

    public virtual DbSet<ThtDetallehabitacion> ThtDetallehabitacion { get; set; }

    public virtual DbSet<ThtHabitacion> ThtHabitacion { get; set; }

    public virtual DbSet<ThtReservacion> ThtReservacion { get; set; }

    public virtual DbSet<ThtTipohabitacion> ThtTipohabitacion { get; set; }

    public virtual DbSet<ThtUsuario> ThtUsuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
