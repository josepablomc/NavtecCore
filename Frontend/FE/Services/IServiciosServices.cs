using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IServiciosServices
    {
        void Insert(Servicios t);
        void Update(Servicios t);
        void Delete(Servicios t);
        IEnumerable<Servicios> GetAll();
        Servicios GetOneById(int id);
        Task<IEnumerable<Servicios>> GetAllAsync();
        Task<Servicios> GetOneByIdAsync(int id);
    }
}
