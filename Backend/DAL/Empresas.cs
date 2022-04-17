using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL
{

    public class Empresas : ICRUD<data.Empresas>
    {
        private RepositoryEmpresas repo;
        public Empresas(NDbContext dbContext)
        {
            repo = new RepositoryEmpresas(dbContext);
        }
        public void Delete(data.Empresas t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Empresas> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Empresas>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Empresas GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Empresas> GetOneByIdAsync(int Id)
        {
            return repo.GetOneByIdAsync(Id);
        }

        public void Insert(data.Empresas t)
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

        public void Update(data.Empresas t)
        {
            repo.Update(t);
            repo.Commit();
        }

    }
}
