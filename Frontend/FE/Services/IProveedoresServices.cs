using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
   public interface IProveedoresServices
    {
        void Insert(Proveedores t);
        void Update(Proveedores t);
        void Delete(Proveedores t);
        IEnumerable<Proveedores> GetAll();
        Proveedores GetOneById(int id);
        Task<IEnumerable<Proveedores>> GetAllAsync();
        Task<Proveedores> GetOneByIdAsync(int id);
    }
}
