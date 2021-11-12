// https://twitter.com/okyrylchuk/status/1448749851596972035

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

MySettings options = new();

// Throws InvalidOperationException if a required section of configuration is missing
app.Configuration.GetRequiredSection("MySettings").Bind(options);

Console.WriteLine(options.SettingValue); // Test setting

app.Run();

class MySettings
{
    public string? SettingValue { get; set; }
}

