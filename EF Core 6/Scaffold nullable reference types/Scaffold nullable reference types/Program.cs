// https://twitter.com/okyrylchuk/status/1461096903106572295

using Scaffold_nullable_reference_types.Models;

using var context = new ExampleContext();

// CREATE TABLE[Posts] (
//        [Id] int NOT NULL IDENTITY,
//        [Name] nvarchar(max) NOT NULL,
//        [Description] nvarchar(max) NULL,
//        CONSTRAINT[PK_Posts] PRIMARY KEY([Id]));

// Package Manager Console
// Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=EFCore6Many2Many;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Context ExampleContext -OutputDir Models

// CLI
// dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCore6Many2Many" Microsoft.EntityFrameworkCore.SqlServer --context ExampleContext --output-dir Models