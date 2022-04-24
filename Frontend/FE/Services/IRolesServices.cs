using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IRolesServices
    {
        void Insert(Roles t);
        void Update(Roles t);
        void Delete(Roles t);
        IEnumerable<Roles> GetAll();
        Roles GetOneById(int id);
        Task<IEnumerable<Roles>> GetAllAsync();
        Task<Roles> GetOneByIdAsync(int id);
    }
}
