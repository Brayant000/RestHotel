namespace SGA.Domain.Entities.Clientes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
}