using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL
{
    //Use this one when no relationship required!!!!!!!!!!!!!!!!!!!!!!!!!!!

    public class Servicios : ICRUD<data.Servicios>
    {
        private Repository<data.Servicios> repo;
        public Servicios(NDbContext dBContext)
        {
            repo = new Repository<data.Servicios>(dBContext);
        }

        public void Delete(data.Servicios t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Servicios> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Servicios>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Servicios GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Servicios> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Servicios t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Servicios t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
