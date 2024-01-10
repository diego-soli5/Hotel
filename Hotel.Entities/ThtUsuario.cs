using System;
using System.Collections.Generic;

namespace Hotel.Entities;

public partial class ThtUsuario : Base
{
    //public int TnIdUsuario { get; set; }

    public string TcNombre { get; set; } = null!;

    public string TcNombreUsuario { get; set; } = null!;

    public string TcClave { get; set; } = null!;

    public string TcCorreo { get; set; } = null!;

    //public bool TbEstado { get; set; }
}
