using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IUsuariosServices
    {
        void Insert(Usuarios t);
        void Update(Usuarios t);
        void Delete(Usuarios t);
        IEnumerable<Usuarios> GetAll();
        Usuarios GetOneById(int id);
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios> GetOneByIdAsync(int id);
    }
}
