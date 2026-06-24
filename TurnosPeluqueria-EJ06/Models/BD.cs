namespace TurnosPeluqueria_EJ06.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using TurnosPeluqueria_EJ06.Models;


public class BD
{
    public string _connectionString = @"Server=localhost; DataBase = TurnosDB; Integrated Security=True; TrustServerCertificate=True;"; 
    


    public List<Turno> ObtenerTurnos()
    {
         List <Turno> turnos = new List<Turno>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Turnos";
            turnos = connection.Query<Turno>(query).ToList();
        }
        return turnos; 
    }

    public void AgregarTurno(Turno t)
    {
        string query = "INSERT INTO Turnos (NombreCliente, Servicio, FechaHora, Estado) VALUES (@NombreCliente, @Servicio, @FechaHora, @Estado)";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query , new { NombreCliente = t.NombreCliente, Servicio = t.Servicio, FechaHora = t.FechaHora, Estado = t.Estado }); 
        }
    }


    
    public void CambiarEstado(int id, string nuevoEstado)
    {
        string query = "UPDATE [Turnos] SET Estado = @nuevoEstado WHERE Id = @id";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { NuevoEstado = nuevoEstado, Id = id });
        }
    
    }
    public void CambiarHorario(int id, DateTime fecha)
    {
        string query = "UPDATE [Turnos] SET FechaHora = @fecha WHERE Id = @Id";
        
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { FechaHora = fecha, Id = id });
        }
    }
}