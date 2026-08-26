using Microsoft.Data.SqlClient;
using Dapper;

public class BD
{
    private string connectionString = "Server=localhost;Database=sala_de_escape;User Id=sa;Password=123456;TrustServerCertificate=True;";

    public int CrearPartida(string nombre)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Partida (Nombre, FechaCreacion) VALUES (@Nombre, GETDATE())";
            connection.Execute(query, new { Nombre = nombre });
            int idPartida = connection.QueryFirstOrDefault<int>("SELECT TOP 1 Id FROM Partida ORDER BY Id DESC");

        }
        return idPartida;
    }
    //bd.FinalizarPartida(idPartida);  sabiendo public class Partida
    public void FinalizarPartida(int idPartida)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Partida SET FechaFin = GETDATE(), Estado = 0 WHERE Id = @Id";
            connection.Execute(query, new { Id = idPartida });
        }
    }
}