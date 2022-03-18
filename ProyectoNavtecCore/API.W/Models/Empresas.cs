using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Empresas
    {
        public int IdEmpresa { get; set; }
        public int IdCliente { get; set; }
        public string NombreEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string CedulaJuridica { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
    }
}
