using FE.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Identity.Services
{
    public interface IEmpresasServices
    {
        void Insert(Empresas t);
        void Update(Empresas t);
        void Delete(Empresas t);
        IEnumerable<Empresas> GetAll();
        Empresas GetOneById(int id);
        Task<IEnumerable<Empresas>> GetAllAsync();
        Task<Empresas> GetOneByIdAsync(int id);
    }
}
