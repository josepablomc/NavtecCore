using FE.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Identity.Services
{
    public interface IClientesServices
    {
        void Insert(Clientes t);
        void Update(Clientes t);
        void Delete(Clientes t);
        IEnumerable<Clientes> GetAll();
        Clientes GetOneById(int id);
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes> GetOneByIdAsync(int id);
    }
}
