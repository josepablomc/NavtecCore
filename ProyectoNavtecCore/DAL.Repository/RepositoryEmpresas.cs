
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{


    public class RepositoryEmpresas : Repository<data.Empresas>, IRepositoryEmpresas
    {
        public RepositoryEmpresas(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Empresas>> GetAllAsync()
        {
            return await _db.Empresas.Include(n => n.Clientes).Include(m => m.IdCliente).ToListAsync();//Relationship between db tables (No se puede Insertar una empresa sin Incluir el idCliente)
        }

        public async Task<data.Empresas> GetOneByIdAsync(int Id)
        {
            return await _db.Empresas.Include(n => n.Clientes).Include(m => m.IdCliente).SingleOrDefaultAsync(n => n.IdCliente == Id);
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
