// https://twitter.com/okyrylchuk/status/1448749851596972035

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

MySettings options = new();

// Throws InvalidOperationException if a required section of configuration is missing
app.Configuration.GetRequiredSection("MySettings").Bind(options);

app.MapGet("/configurationSettings", () =>
{
    return options.SettingValue;
})
.WithName("GetConfigurationSettings");

Console.WriteLine(options.SettingValue); // Test setting

app.Run();

class MySettings
{
    public string? SettingValue { get; set; }
}
