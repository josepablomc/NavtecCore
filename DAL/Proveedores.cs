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

    public class Proveedores : ICRUD<data.Proveedores>
    {
        private Repository<data.Proveedores> repo;
        public Proveedores(NDbContext dBContext)
        {
            repo = new Repository<data.Proveedores>(dBContext);
        }

        public void Delete(data.Proveedores t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Proveedores> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Proveedores>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Proveedores GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Proveedores> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Proveedores t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Proveedores t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
