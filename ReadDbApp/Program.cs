using System.Data.SQLite;
using System;
using System.IO;

var dbPath = "CyberpunkBackend/Data/contacts.db";
if (!File.Exists(dbPath))
{
    Console.WriteLine($"Database file not found: {dbPath}");
    return;
}

using var connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
connection.Open();
using var command = new SQLiteCommand("SELECT * FROM Contacts;", connection);
using var reader = command.ExecuteReader();
while (reader.Read())
{
    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Surname: {reader["Surname"]}, Email: {reader["Email"]}, Timestamp: {reader["Timestamp"]}");
}
connection.Close();
