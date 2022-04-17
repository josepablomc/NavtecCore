using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryUsuarios : IRepository<data.Usuarios>
    {
        Task<IEnumerable<data.Usuarios>> GetAllAsync();
        Task<data.Usuarios> GetOneByIdAsync(int Id);//Same signature
    }
}
