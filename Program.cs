var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddTransient<ILoginService, LoginService>();
// builder.Services.AddSingleton<ILoginService, LoginService>();

var app = builder.Build();

app.Use( async(context, next) =>
{
    var loginService = context.RequestServices.GetService<ILoginService>();
    loginService.Authenticate("test", "testPassword");
    await next();
});

app.Use( async(context, next) =>
{
    var loginService = context.RequestServices.GetService<ILoginService>();
    loginService.Authenticate("user2", "testPassword2");
    await next();
});

app.Use( async(context, next) =>
{
    var loginService = context.RequestServices.GetService<ILoginService>();
    loginService.Authenticate("user3", "testPassword3");
    await next();
});




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

