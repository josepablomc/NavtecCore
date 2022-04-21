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


    public class Cotizaciones : ICRUD<data.Cotizaciones>
    {
        private dal.Cotizaciones _dal;
        public Cotizaciones(NDbContext dbContext)
        {
            _dal = new dal.Cotizaciones(dbContext);
        }
        public void Delete(data.Cotizaciones t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Cotizaciones> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Cotizaciones>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Cotizaciones GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Cotizaciones> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Cotizaciones t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Cotizaciones t)
        {
            _dal.Update(t);
        }
    }
}

