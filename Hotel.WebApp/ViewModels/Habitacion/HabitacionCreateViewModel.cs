using Hotel.WebApp.Models.Habitacion;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.WebApp.ViewModels.Habitacion
{
    public class HabitacionCreateViewModel
    {
        public HabitacionCreateDTO Habitacion { get; set; }
        public IEnumerable<SelectListItem> TipoHabitacionSelectListItems { get; set; }
    }
}
