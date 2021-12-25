// https://twitter.com/okyrylchuk/status/1461456537357008897

using Database_comments_are_scaffolded_to_code_comments.Models;

using var context = new ExampleContext();

/*
    CREATE TABLE [Posts] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]));

    EXEC sp_addextendedproperty 
        @name = N'MS_Description', @value = 'The post table',
        @level0type = N'Schema', @level0name = dbo, 
        @level1type = N'Table',  @level1name = Posts

    EXEC sp_addextendedproperty 
        @name = N'MS_Description', @value = 'The post identifier',
        @level0type = N'Schema', @level0name = dbo, 
        @level1type = N'Table',  @level1name = Posts, 
        @level2type = N'Column', @level2name = [Id];

    EXEC sp_addextendedproperty 
        @name = N'MS_Description', @value = 'The post name',
        @level0type = N'Schema', @level0name = dbo, 
        @level1type = N'Table',  @level1name = Posts, 
        @level2type = N'Column', @level2name = [Name];

    EXEC sp_addextendedproperty 
        @name = N'MS_Description', @value = 'The description name',
        @level0type = N'Schema', @level0name = dbo, 
        @level1type = N'Table',  @level1name = Posts, 
        @level2type = N'Column', @level2name = [Description];
*/

// Package Manager Console
// Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=EFCore6Many2Many;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Context ExampleContext -OutputDir Models

// CLI
// dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EFCore6Many2Many" Microsoft.EntityFrameworkCore.SqlServer --context ExampleContext --output-dir Models