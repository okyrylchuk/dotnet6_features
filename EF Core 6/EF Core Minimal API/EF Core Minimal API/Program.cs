// https://twitter.com/okyrylchuk/status/1458203237400649728

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

const string AccountKey = "";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<MyDbContext>(@"Server = (localdb)\mssqllocaldb; Database = MyDatabase");

// OR
builder.Services.AddSqlite<MyDbContext>("Data Source=mydatabase.db");

// OR
builder.Services.AddCosmos<MyDbContext>($"AccountEndpoint=https://localhost:8081/;AccountKey={AccountKey}", "MyDatabase");

var app = builder.Build();
app.Run();

class MyDbContext : DbContext
{ }
