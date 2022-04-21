using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Empresas = new HashSet<Empresas>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }

        public virtual ICollection<Empresas> Empresas { get; set; }
    }
}
