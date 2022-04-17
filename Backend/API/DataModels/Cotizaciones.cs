using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.DataModels
{
    public partial class Cotizaciones
    {
        [Key]
        public int IdCotizacion { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public string NombreCliente { get; set; }
        public decimal PrecioCotizacion { get; set; }

        public virtual Servicios IdServicioNavigation { get; set; }
    }
}
