using System;
using System.Collections.Generic;

namespace Hotel.Entities;

public partial class ThtTipohabitacion : Base
{
   //public int TnIdTipoHabitacion { get; set; }

    public string TcNomTipoHabitacion { get; set; } = null!;

    //public bool TbEstado { get; set; }

    public virtual ICollection<ThtHabitacion> ThtHabitacions { get; set; } = new List<ThtHabitacion>();
}
