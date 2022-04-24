using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface ICotizacionesServices
    {
        void Insert(Cotizaciones t);
        void Update(Cotizaciones t);
        void Delete(Cotizaciones t);
        IEnumerable<Cotizaciones> GetAll();
        Cotizaciones GetOneById(int id);
        Task<IEnumerable<Cotizaciones>> GetAllAsync();
        Task<Cotizaciones> GetOneByIdAsync(int id);
    }
}
