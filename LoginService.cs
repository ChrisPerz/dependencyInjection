public class LoginService : ILoginService
{
    private string _serviceId;
    public LoginService()
    {
        // Constructor logic here
        _serviceId = new Random().Next(1000, 9999).ToString();
    }
    public void Authenticate(string name, string password)
    {
        Console.WriteLine($"Service ID: {_serviceId}");
        // Authentication logic here
        Console.WriteLine($"Authenticating user {name} with password {password}");
    }
    public void Logout()
    {
        // Logout logic here
        Console.WriteLine("Logging out");
    }
}