
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{


    public class RepositoryCotizaciones : Repository<data.Cotizaciones>, IRepositoryCotizaciones
    {
        public RepositoryCotizaciones(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Cotizaciones>> GetAllAsync()
        {
            return await _db.Cotizaciones.Include(n => n.Servicios).ToListAsync();//Relationship between db tables (No se puede Insertar una Cotizacion en la DB sin Incluir el idRServicio)
        }

        public async Task<data.Cotizaciones> GetOneByIdAsync(int Id)
        {
            return await _db.Cotizaciones.Include(n => n.Servicios).Include(m => m.IdServicio).SingleOrDefaultAsync(n => n.IdServicio == Id);
        }
        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
