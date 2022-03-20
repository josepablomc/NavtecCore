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


    public class Usuarios : ICRUD<data.Usuarios>
    {
        private dal.Usuarios _dal;
        public Usuarios(NDbContext dbContext)
        {
            _dal = new dal.Usuarios(dbContext);
        }
        public void Delete(data.Usuarios t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Usuarios>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Usuarios GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Usuarios> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Usuarios t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Usuarios t)
        {
            _dal.Update(t);
        }
    }
}

