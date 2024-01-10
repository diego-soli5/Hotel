using System;
using System.Collections.Generic;

namespace Hotel.Entities;

public partial class ThtCliente : Base
{
    //public int TnIdCliente { get; set; }

    public string TcNombre { get; set; } = null!;

    public string TcAp1 { get; set; } = null!;

    public string TcAp2 { get; set; } = null!;

    public string TcNumTelefono { get; set; } = null!;

    public string TcCorreoElectronico { get; set; } = null!;

    //public bool TbEstado { get; set; }

    public virtual ICollection<ThtReservacion> ThtReservacion { get; set; } = new List<ThtReservacion>();
}
