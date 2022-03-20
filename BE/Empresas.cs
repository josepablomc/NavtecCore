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


    public class Empresas : ICRUD<data.Empresas>
    {
        private dal.Empresas _dal;
        public Empresas(NDbContext dbContext)
        {
            _dal = new dal.Empresas(dbContext);
        }
        public void Delete(data.Empresas t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Empresas> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Empresas>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Empresas GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Empresas> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Empresas t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Empresas t)
        {
            _dal.Update(t);
        }
    }
}

