using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryEmpresas : IRepository<data.Empresas>
    {
        Task<IEnumerable<data.Empresas>> GetAllAsync();
        Task<data.Empresas> GetOneByIdAsync(int Id);//Signature
    }
}
