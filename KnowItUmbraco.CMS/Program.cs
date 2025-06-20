WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Starting Umbraco builder configuration...");
builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();
Console.WriteLine("Umbraco builder configuration completed");

Console.WriteLine("Building application...");
WebApplication app = builder.Build();
Console.WriteLine("Application built successfully");

Console.WriteLine("Booting Umbraco...");
await app.BootUmbracoAsync();
Console.WriteLine("Umbraco booted successfully");

Console.WriteLine("Configuring Umbraco middleware and endpoints...");
app.UseUmbraco()
    .WithMiddleware(u =>
    {
        Console.WriteLine("Setting up Umbraco middleware - BackOffice");
        u.UseBackOffice();
        Console.WriteLine("Setting up Umbraco middleware - Website");
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        Console.WriteLine("Setting up Umbraco endpoints - Installer");
        u.UseInstallerEndpoints();
        Console.WriteLine("Setting up Umbraco endpoints - BackOffice");
        u.UseBackOfficeEndpoints();
        Console.WriteLine("Setting up Umbraco endpoints - Website");
        u.UseWebsiteEndpoints();
    });
Console.WriteLine("Umbraco middleware and endpoints configured");

Console.WriteLine("Starting application...");
await app.RunAsync();
