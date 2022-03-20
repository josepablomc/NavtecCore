using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.DO.Objects
{
    public partial class Empresas
    {
        //public Empresas()
        //{
        //    Clientes = new HashSet<Clientes>();
        //}

        public int IdEmpresa { get; set; }
        [Key] //To define this is a Foreingnkey 
        public int IdCliente { get; set; }
        public string NombreEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string CedulaJuridica { get; set; }

        public virtual Clientes Clientes { get; set; } //Para detectar el ForeignKey de idCliente que necesita Empresas para crear una nueva Empresa
    }
}
