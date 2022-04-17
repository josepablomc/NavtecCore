using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using dal = DAL;
using DAL.DO.Interfaces;
using System.Threading.Tasks;
using DAL.EF;

namespace BE
{


    public class Servicios : ICRUD<data.Servicios>
    {
        private dal.Servicios _dal;
        public Servicios(NDbContext dbContext)
        {
            _dal = new dal.Servicios(dbContext);
        }
        public void Delete(data.Servicios t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Servicios> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Servicios>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Servicios GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Servicios> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Servicios t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Servicios t)
        {
            _dal.Update(t);
        }
    }
}

