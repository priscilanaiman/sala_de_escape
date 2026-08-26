public class Partida
{
	public int Id { get; set; }
	public int ParticipanteId { get; set; }
	public DateTime FechaInicio { get; set; }
	public DateTime? FechaFin { get; set; }
	public bool Estado { get; set; }
}