using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.DO.Objects
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        //[Key] //To define this is a Foreingnkey 
        public int IdRol { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoUsuario { get; set; }
        public string ClaveUsuario { get; set; }

        public virtual Roles Roles { get; set; } //Para detectar el ForeignKey de idRol que necesita Usuarios para crear un nuevo usuario

    }
}
