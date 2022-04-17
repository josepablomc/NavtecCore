using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace DAL.DO.Objects
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
