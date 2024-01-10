using Hotel.DataAccess.Abstractions;
using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess.Repositories
{
    public class TipoHabitacionRepository : Repository<ThtTipohabitacion>, ITipoHabitacionRepository
    {
        public TipoHabitacionRepository(HotelContext context) : base(context)
        {
        }
    }
}
