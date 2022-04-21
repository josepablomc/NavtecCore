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

    public class Roles : ICRUD<data.Roles>
    {
        private Repository<data.Roles> repo;
        public Roles(NDbContext dBContext)
        {
            repo = new Repository<data.Roles>(dBContext);
        }

        public void Delete(data.Roles t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Roles>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Roles GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Roles> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Roles t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Roles t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
