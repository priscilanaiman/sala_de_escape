using Microsoft.Data.SqlClient;
using Dapper;

public class BD
{
    private string connectionString = @"Server=localhost;Database=sala_de_escape;Integrated Security=True;TrustServerCertificate=True;";

    public int CrearPartida(int idParticipante)
    {
        int idPartida;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            idPartida = connection.QueryFirstOrDefault<int>("SELECT TOP 1 Id FROM Partida ORDER BY Id DESC");
            string query = "INSERT INTO Partida (ParticipanteId, FechaInicio, Estado) VALUES (@ParticipanteId, GETDATE(), 1)";
            connection.Execute(query, new { ParticipanteId = idParticipante,});

        }
        return idPartida + 1;
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
    //obtener id participante desde su nombre
    public int ObtenerIdParticipante(string nombre)
    {
        int idParticipante;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id FROM Participante WHERE Nombre = @Nombre";
            idParticipante = connection.QueryFirstOrDefault<int>(query, new { Nombre = nombre });
        }
        return idParticipante;
    }
    //crear participante
    public void CrearParticipante(string nombre)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Participante (Nombre, FechaCreacion) VALUES (@Nombre, GETDATE())";
            connection.Execute(query, new { Nombre = nombre });
        }
    }
}