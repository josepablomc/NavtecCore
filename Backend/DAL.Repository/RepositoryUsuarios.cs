
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{


    public class RepositoryUsuarios : Repository<data.Usuarios>, IRepositoryUsuarios
    {
        public RepositoryUsuarios(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Usuarios>> GetAllAsync()
        {
            //return await _db.Usuarios.Include(n => n.Roles).Include(m => m.IdRol).ToListAsync();//Relationship between db tables (No se puede Insertar un Usuario en la DB sin Incluir el idRole)
            return await _db.Usuarios.Include(n => n.Roles).ToListAsync();
        }

        public async Task<data.Usuarios> GetOneByIdAsync(int Id)
        {
            return await _db.Usuarios.Include(n => n.Roles).SingleOrDefaultAsync(n => n.IdUsuario == Id);
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
