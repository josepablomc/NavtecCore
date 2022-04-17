using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL
{

    public class Clientes : ICRUD<data.Clientes>
    {
        private Repository<data.Clientes> repo;
        public Clientes(NDbContext dBContext)
        {
            repo = new Repository<data.Clientes>(dBContext);
        }

        public void Delete(data.Clientes t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Clientes> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Clientes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Clientes GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Clientes> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Clientes t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Clientes t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
