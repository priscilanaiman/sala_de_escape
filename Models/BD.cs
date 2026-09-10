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
            string query = "INSERT INTO Partida (ParticipanteId, FechaInicio, Estado, SalaActual) VALUES (@ParticipanteId, GETDATE(), 1, 1)";
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
    public int ObtenerIdPartida(string nombre)
    {
        int idPartida;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT Id FROM Partida WHERE ParticipanteId = (SELECT Id FROM Participante WHERE Nombre = @Nombre)";
            idPartida = connection.QueryFirstOrDefault<int>(query, new { Nombre = nombre });
        }
        return idPartida;
    }
    public int ObtenerSalaActual(int idPartida)
    {
        int salaActual;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT SalaActual FROM Partida WHERE Id = @Id";
            salaActual = connection.QueryFirstOrDefault<int>(query, new { Id = idPartida });
        }
        return salaActual;
    }
    public void actualizarSalaActual(int idPartida, int salaActual)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Partida SET SalaActual = @SalaActual WHERE Id = @Id";
            connection.Execute(query, new { SalaActual = salaActual, Id = idPartida });
        }
    }
}