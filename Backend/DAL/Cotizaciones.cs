using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL
{

    public class Cotizaciones : ICRUD<data.Cotizaciones>
    {
        private RepositoryCotizaciones repo;
        public Cotizaciones(NDbContext dbContext)
        {
            repo = new RepositoryCotizaciones(dbContext);
        }
        public void Delete(data.Cotizaciones t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Cotizaciones> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Cotizaciones>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Cotizaciones GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Cotizaciones> GetOneByIdAsync(int Id)
        {
            return repo.GetOneByIdAsync(Id);
        }

        public void Insert(data.Cotizaciones t)
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

        public void Update(data.Cotizaciones t)
        {
            repo.Update(t);
            repo.Commit();
        }

    }
}
