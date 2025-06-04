var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<ILoginService, LoginService>();
// builder.Services.AddSingleton<ILoginService, LoginService>();

var app = builder.Build();




app.MapGet("/", (ILoginService loginService) =>
{
    loginService.Authenticate("ROOT", "Password");
    return "Hello World!";
});

app.MapGet("/test", (ILoginService loginService) =>
{
    loginService.Authenticate("testRoute", "PasswordTest");
    return "Hello test!";
});

app.Run();

