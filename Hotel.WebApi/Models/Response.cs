namespace Hotel.WebApi.Models
{
    public class Response
    {
        public Response() { }
        public Response(string message)
        {
            Message = message;
        }
        public Response(object data, string message)
        {
            Data = data;
            Message = message;
        }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}
