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


    public class Proveedores : ICRUD<data.Proveedores>
    {
        private dal.Proveedores _dal;
        public Proveedores(NDbContext dbContext)
        {
            _dal = new dal.Proveedores(dbContext);
        }
        public void Delete(data.Proveedores t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Proveedores> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Proveedores>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Proveedores GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Proveedores> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Proveedores t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Proveedores t)
        {
            _dal.Update(t);
        }
    }
}

