using FE.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Identity.Services
{
    public interface IGastosServices
    {
        void Insert(Gastos t);
        void Update(Gastos t);
        void Delete(Gastos t);
        IEnumerable<Gastos> GetAll();
        Gastos GetOneById(int id);
        Task<IEnumerable<Gastos>> GetAllAsync();
        Task<Gastos> GetOneByIdAsync(int id);
    }
}
