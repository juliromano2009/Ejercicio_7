namespace TurnosPeluqueria_EJ06.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using TurnosPeluqueria_EJ06.Models;


public class BD
{
    private string _connectionString =
        @"";

    
    public string _connectionString = @"Server=localhost; DataBase = TurnosBD; Integrated Security=True; TrustServerCertificate=True;"; 


    public List<Turno> ObtenerTurnos()
    {
        

    }

    public int AgregarTurno(Turno t)
    {
        // TODO
    }


    /*
    public int CambiarEstado(int id, string nuevoEstado)
    {
        // TODO

        throw new NotImplementedException();
    }
    */
}