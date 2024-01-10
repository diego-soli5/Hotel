using Hotel.WebApp.Utils.Options;
using Microsoft.Extensions.Options;

namespace Hotel.WebApp.Utils.ApiRoutes
{
    public class ClienteRoutes
    {
        private readonly ApiOptions apiOptions;
        private readonly string Cliente;

        public ClienteRoutes(IOptions<ApiOptions> options)
        {
            apiOptions = options.Value;

            Cliente = $"{apiOptions.Domain}/api/{nameof(Cliente)}";
        }

        public string GetById
        {
            get
            {
                return $"{Cliente}/{nameof(GetById)}";
            }
        }

        public string GetAll
        {
            get
            {
                return $"{Cliente}/{nameof(GetAll)}";
            }
        }

        public string Create
        {
            get
            {
                return $"{Cliente}/{nameof(Create)}";
            }
        }

        public string Update
        {
            get
            {
                return $"{Cliente}/{nameof(Update)}";
            }
        }

        public string Delete
        {
            get
            {
                return $"{Cliente}/{nameof(Delete)}";
            }
        }
    }
}
