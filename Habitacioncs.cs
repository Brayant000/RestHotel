namespace SGA.Domain.Entities.Reservas
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }
    }
}