using System;

namespace SGA.Domain.Entities.Clientes
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        
        public Cliente()
        {
            Estado = true;
            FechaCreacion = DateTime.Now;
        }
    }
}