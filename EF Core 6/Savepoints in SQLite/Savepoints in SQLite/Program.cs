// https://twitter.com/okyrylchuk/status/1467975488052289536

using Microsoft.Data.Sqlite;

var dbPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\Savepoints.db"));

using var connection = new SqliteConnection($"Data Source={dbPath}");
connection.Open();
using var transaction = connection.BeginTransaction();

// The insert is committed to the database
using (var command = connection.CreateCommand())
{
    command.CommandText = @"INSERT INTO People (Name) VALUES ('Oleg')";
    command.ExecuteNonQuery();
}

transaction.Save("MySavepoint");

// The update is not commited since savepoint is rolled back before commiting the transaction
using (var command = connection.CreateCommand())
{
    command.CommandText = @"UPDATE People SET Name = 'Not Oleg' WHERE Id = 1";
    command.ExecuteNonQuery();
}

transaction.Rollback("MySavepoint");
transaction.Commit();

