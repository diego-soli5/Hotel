using System;
using System.Collections.Generic;

namespace Hotel.Entities;

public partial class ThtDetallehabitacion 
{
    public int? TnIdHabitacion { get; set; }

    public string TcTamanoHabitacion { get; set; } = null!;

    public string TcDscAmenidades { get; set; } = null!;

    public virtual ThtHabitacion? TnIdHabitacionNavigation { get; set; }
}
