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


    public class Clientes : ICRUD<data.Clientes>
    {
        private dal.Clientes _dal;
        public Clientes(NDbContext dbContext)
        {
            _dal = new dal.Clientes(dbContext);
        }
        public void Delete(data.Clientes t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Clientes> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Clientes>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Clientes GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Clientes> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Clientes t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Clientes t)
        {
            _dal.Update(t);
        }
    }
}

