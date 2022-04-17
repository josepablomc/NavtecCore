using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL
{

    public class Usuarios : ICRUD<data.Usuarios>
    {
        private RepositoryUsuarios repo;
        public Usuarios(NDbContext dbContext)
        {
            repo = new RepositoryUsuarios(dbContext);
        }
        public void Delete(data.Usuarios t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Usuarios>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Usuarios GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Usuarios> GetOneByIdAsync(int Id)
        {
            return repo.GetOneByIdAsync(Id);
        }

        public void Insert(data.Usuarios t)
        {
            try
            {
                repo.Insert(t);
                repo.Commit();
            }
            catch (Exception ee)
            {

                throw;
            }

        }

        public void Update(data.Usuarios t)
        {
            repo.Update(t);
            repo.Commit();
        }

    }
}
