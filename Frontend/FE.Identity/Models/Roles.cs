﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Identity.Models
{
    public partial class Roles
    {
        public Roles()
        {
         Usuarios = new HashSet<Usuarios>();
        }

        public int IdRol { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
