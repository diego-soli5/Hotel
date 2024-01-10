namespace Hotel.BusinessLogic.Abstractions
{
    public interface IPasswordService
    {
        bool Check(string hashedPassword, string plainPassword);
        string Hash(string plainPassword);
    }
}
