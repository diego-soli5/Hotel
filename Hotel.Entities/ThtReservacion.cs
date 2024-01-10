using System;
using System.Collections.Generic;

namespace Hotel.Entities;

public partial class ThtReservacion : Base
{
    //public int TnNumReservacion { get; set; }

    public int TnIdCliente { get; set; }

    public int TnIdHabitacion { get; set; }

    public DateTime TfFecInicio { get; set; }

    public DateTime TfFecFin { get; set; }

    //public bool TbEstado { get; set; }

    public virtual ThtCliente TnIdClienteNavigation { get; set; } = null!;

    public virtual ThtHabitacion TnIdHabitacionNavigation { get; set; } = null!;
}
