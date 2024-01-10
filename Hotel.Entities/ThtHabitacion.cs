using System;
using System.Collections.Generic;

namespace Hotel.Entities;

public partial class ThtHabitacion : Base
{
    //public int TnIdHabitacion { get; set; }

    public string TcNombreHabitacion { get; set; } = null!;

    public string TcDscHabitacion { get; set; } = null!;

    public int TnIdTipoHabitacion { get; set; }

    //public bool TbEstado { get; set; }

    public decimal TdPrecioXnoche { get; set; }

    public virtual ThtDetallehabitacion? ThtDetallehabitacionNavigation { get; set; }

    public virtual ICollection<ThtReservacion> ThtReservacions { get; set; } = new List<ThtReservacion>();

    public virtual ThtTipohabitacion TnIdTipoHabitacionNavigation { get; set; } = null!;
}
