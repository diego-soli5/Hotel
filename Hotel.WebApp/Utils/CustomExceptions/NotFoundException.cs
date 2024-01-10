namespace Hotel.WebApp.Utils.CustomExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string? message) : base(message)
        {
            
        }
    }
}
