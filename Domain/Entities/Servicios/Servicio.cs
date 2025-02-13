namespace SGA.Domain.Entities.Servicios
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public required string Nombre { get; set; } = string.Empty;
        public required string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
    }
}
