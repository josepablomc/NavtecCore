
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
            return await _db.Empresas.Include(n => n.Clientes).ToListAsync();//Relationship between db tables
        }

        public async Task<data.Empresas> GetOneByIdAsync(int Id)
        {
            return await _db.Empresas.Include(n => n.Clientes).SingleOrDefaultAsync(n => n.IdEmpresa == Id);
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
