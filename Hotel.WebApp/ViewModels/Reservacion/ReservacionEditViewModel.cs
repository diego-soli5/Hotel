using Hotel.WebApp.Models.Reservacion;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.WebApp.ViewModels.Reservacion
{
    public class ReservacionEditViewModel
    {
        public ReservacionDTO Reservacion { get; set; }
        public IEnumerable<SelectListItem> ClienteSelectListItems { get; set; }
        public IEnumerable<SelectListItem> HabitacionSelectListItems { get; set; }
    }
}
