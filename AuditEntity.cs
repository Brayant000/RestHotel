using System;

namespace SGA.Domain.Base
{
    public abstract class AuditEntity
    {
        protected AuditEntity()
        {
            this.Estado = true;
            this.FechaCreacion = DateTime.Now;
        }

        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}