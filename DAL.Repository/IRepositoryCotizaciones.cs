using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryCotizaciones : IRepository<data.Cotizaciones>
    {
        Task<IEnumerable<data.Cotizaciones>> GetAllAsync();
        Task<data.Cotizaciones> GetOneByIdAsync(int Id);
    }
}
