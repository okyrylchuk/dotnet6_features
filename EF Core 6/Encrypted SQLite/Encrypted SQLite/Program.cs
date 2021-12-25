// https://twitter.com/okyrylchuk/status/1467245380794556423

using Microsoft.EntityFrameworkCore;

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=EncryptedDb.db;Mode=ReadWriteCreate;Password=password");
}

