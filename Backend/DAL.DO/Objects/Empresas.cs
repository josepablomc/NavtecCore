using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace DAL.DO.Objects
{
    public partial class Empresas
    {

        public int IdEmpresa { get; set; }
        //To define this is a Foreingnkey 
        public int IdCliente { get; set; }
        public string NombreEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string CedulaJuridica { get; set; }

        public virtual Clientes Clientes { get; set; } //Para detectar el ForeignKey de idCliente que necesita Empresas para crear una nueva Empresa
    }
}
