using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.DataModels
{
    public partial class Servicios
    {
        //public Servicios()
        //{
        //    Cotizaciones = new HashSet<Cotizaciones>();
        //}

        public int IdServicio { get; set; }
        public string DescripcionServicio { get; set; }

        //public virtual ICollection<Cotizaciones> Cotizaciones { get; set; }
    }
}
