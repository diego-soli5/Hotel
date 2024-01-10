using Hotel.WebApp.Models.Habitacion;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.WebApp.ViewModels.Habitacion
{
    public class HabitacionEditViewModel
    {
        public HabitacionDTO Habitacion { get; set; }
        public IEnumerable<SelectListItem> TipoHabitacionSelectListItems { get; set; }
    }
}
