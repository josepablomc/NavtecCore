using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Identity.Models
{
    public partial class Cotizaciones
    {
        public int IdCotizacion { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public string NombreCliente { get; set; }
        public decimal PrecioCotizacion { get; set; }

        public virtual Servicios Servicios { get; set; }
    }
}
