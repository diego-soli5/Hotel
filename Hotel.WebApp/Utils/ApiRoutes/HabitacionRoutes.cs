using Hotel.WebApp.Utils.Options;
using Microsoft.Extensions.Options;

namespace Hotel.WebApp.Utils.ApiRoutes
{
    public class HabitacionRoutes
    {
        private readonly ApiOptions apiOptions;
        private readonly string Habitacion;

        public HabitacionRoutes(IOptions<ApiOptions> options)
        {
            apiOptions = options.Value;

            Habitacion = $"{apiOptions.Domain}/api/{nameof(Habitacion)}";
        }

        public string GetById
        {
            get
            {
                return $"{Habitacion}/{nameof(GetById)}";
            }
        }

        public string GetAll
        {
            get
            {
                return $"{Habitacion}/{nameof(GetAll)}";
            }
        }

        public string Create
        {
            get
            {
                return $"{Habitacion}/{nameof(Create)}";
            }
        }

        public string Update
        {
            get
            {
                return $"{Habitacion}/{nameof(Update)}";
            }
        }

        public string Delete
        {
            get
            {
                return $"{Habitacion}/{nameof(Delete)}";
            }
        }
    }
}
