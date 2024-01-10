using Hotel.WebApp.Utils.Options;
using Microsoft.Extensions.Options;

namespace Hotel.WebApp.Utils.ApiRoutes
{
    public class TipoHabitacionRoutes
    {
        private readonly ApiOptions apiOptions;
        private readonly string TipoHabitacion;

        public TipoHabitacionRoutes(IOptions<ApiOptions> options)
        {
            apiOptions = options.Value;

            TipoHabitacion = $"{apiOptions.Domain}/api/{nameof(TipoHabitacion)}";
        }

        public string GetById
        {
            get
            {
                return $"{TipoHabitacion}/{nameof(GetById)}";
            }
        }

        public string GetAll
        {
            get
            {
                return $"{TipoHabitacion}/{nameof(GetAll)}";
            }
        }

        public string Create
        {
            get
            {
                return $"{TipoHabitacion}/{nameof(Create)}";
            }
        }

        public string Update
        {
            get
            {
                return $"{TipoHabitacion}/{nameof(Update)}";
            }
        }

        public string Delete
        {
            get
            {
                return $"{TipoHabitacion}/{nameof(Delete)}";
            }
        }
    }
}
