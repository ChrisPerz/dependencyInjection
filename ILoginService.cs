public interface ILoginService
{
    void Authenticate(string username, string password);
    void Logout();
}