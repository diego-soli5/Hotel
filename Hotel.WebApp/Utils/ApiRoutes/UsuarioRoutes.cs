using Hotel.WebApp.Utils.Options;
using Microsoft.Extensions.Options;

namespace Hotel.WebApp.Utils.ApiRoutes
{
    public class UsuarioRoutes
    {
        private readonly ApiOptions _apiOptions;
        private readonly string Usuario;

        public UsuarioRoutes(IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;

            Usuario = $"{_apiOptions.Domain}/api/{nameof(Usuario)}";
        }

        public string GetAll
        {
            get
            {
                return $"{Usuario}/{nameof(GetAll)}";
            }
        }

        public string Login
        {
            get
            {
                return $"{Usuario}/{nameof(Login)}";
            }
        }

        public string Register
        {
            get
            {
                return $"{Usuario}/{nameof(Register)}";
            }
        }

        public string Delete
        {
            get
            {
                return $"{Usuario}/{nameof(Delete)}";
            }
        }
    }
}
