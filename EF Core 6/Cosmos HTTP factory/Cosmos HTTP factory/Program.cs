using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

class ExampleContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "ExampleDB",
        cosmosOptionsBuilder =>
        {
            cosmosOptionsBuilder.HttpClientFactory(
                () => new HttpClient(
                    new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    }));
        });
}