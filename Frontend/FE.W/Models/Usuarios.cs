using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoUsuario { get; set; }
        public string ClaveUsuario { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
    }
}
