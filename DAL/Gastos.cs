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

    public class Gastos : ICRUD<data.Gastos>
    {
        private Repository<data.Gastos> repo;
        public Gastos(NDbContext dBContext)
        {
            repo = new Repository<data.Gastos>(dBContext);
        }

        public void Delete(data.Gastos t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Gastos> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Gastos>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Gastos GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Gastos> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Gastos t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Gastos t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
