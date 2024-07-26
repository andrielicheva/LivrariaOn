using LivrariaOn;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
public class Program()
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        string connection = "Server=localhost;Database=erp;UserID=root;Password=Crossfox;Port=3306;";
        builder.Services.AddDbContext<BookDbContext>
            (
                options => options.UseMySql(connection, ServerVersion.AutoDetect(connection))
            );
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    public void DbConnectionMySql()
    {
        //Connection string
            string connectionString = "Server=localhost;Database=erp;UserID=root;Password=Crossfoxavc7082@;Port=3306;";

        // Create a connection
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            try
            {
                // Open the connection
                conn.Open();
                Console.WriteLine("Connection successful!");

                // Perform database operations
                string query = "SELECT * FROM livraria";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["titulo"] + " - " + reader["autor"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
