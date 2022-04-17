using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Gastos
    {
        public int IdGasto { get; set; }
        public string DescripcionGasto { get; set; }
        public DateTime FechaGasto { get; set; }
        public decimal MontoGasto { get; set; }
    }
}
