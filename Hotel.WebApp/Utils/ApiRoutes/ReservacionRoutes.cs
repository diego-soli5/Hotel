using Hotel.WebApp.Utils.Options;
using Microsoft.Extensions.Options;

namespace Hotel.WebApp.Utils.ApiRoutes
{
    public class ReservacionRoutes
    {
        private readonly ApiOptions apiOptions;
        private readonly string Reservacion;

        public ReservacionRoutes(IOptions<ApiOptions> options)
        {
            apiOptions = options.Value;

            Reservacion = $"{apiOptions.Domain}/api/{nameof(Reservacion)}";
        }

        public string GetById
        {
            get
            {
                return $"{Reservacion}/{nameof(GetById)}";
            }
        }

        public string GetAll
        {
            get
            {
                return $"{Reservacion}/{nameof(GetAll)}";
            }
        }

        public string Create
        {
            get
            {
                return $"{Reservacion}/{nameof(Create)}";
            }
        }

        public string Update
        {
            get
            {
                return $"{Reservacion}/{nameof(Update)}";
            }
        }

        public string Delete
        {
            get
            {
                return $"{Reservacion}/{nameof(Delete)}";
            }
        }
    }
}
