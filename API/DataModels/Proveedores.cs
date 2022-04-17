using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.DataModels
{
    public partial class Proveedores
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
    }
}
