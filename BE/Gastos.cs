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


    public class Gastos : ICRUD<data.Gastos>
    {
        private dal.Gastos _dal;
        public Gastos(NDbContext dbContext)
        {
            _dal = new dal.Gastos(dbContext);
        }
        public void Delete(data.Gastos t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Gastos> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Gastos>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Gastos GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Gastos> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Gastos t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Gastos t)
        {
            _dal.Update(t);
        }
    }
}

