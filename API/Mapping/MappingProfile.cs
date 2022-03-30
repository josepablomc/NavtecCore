using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<data.Usuarios, DataModels.Usuarios>().ReverseMap(); //Validar que ambos objetos sean iguales.
            CreateMap<data.Roles, DataModels.Roles>().ReverseMap();
            CreateMap<data.Empresas, DataModels.Empresas>().ReverseMap();
            CreateMap<data.Clientes, DataModels.Clientes>().ReverseMap();
            CreateMap<data.Servicios, DataModels.Servicios>().ReverseMap();
            CreateMap<data.Cotizaciones, DataModels.Cotizaciones>().ReverseMap();

        }
    }
}
