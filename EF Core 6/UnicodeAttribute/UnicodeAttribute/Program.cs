// https://twitter.com/okyrylchuk/status/1456010438055968776

using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

Console.WriteLine();

class ExampleContext : DbContext
{
    DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFUnicodeAttribute;Trusted_Connection=True;");
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    [Unicode(false)]
    [MaxLength(22)]
    public string Isbn { get; set; }
}
