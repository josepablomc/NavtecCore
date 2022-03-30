using AutoMapper;
using DAL.DO.Objects;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using models = API.DataModels;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ProveedoresController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Proveedores
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Proveedores>>> GetProveedores()
        {

            var res = new BE.Proveedores(_context).GetAll();
            List<models.Proveedores> mapaAux = _mapper.Map<IEnumerable<data.Proveedores>, IEnumerable<models.Proveedores>>(res).ToList();
            return mapaAux;
        }


        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Proveedores>> GetProveedores(int id)
        {
            var Proveedores = new BE.Proveedores(_context).GetOneById(id);

            if (Proveedores == null)
            {
                return NotFound();
            }
            models.Proveedores mapaAux = _mapper.Map<data.Proveedores, models.Proveedores>(Proveedores);
            return mapaAux;

        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedores(int id, models.Proveedores Proveedores)
        {
            if (id != Proveedores.IdProveedor) //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
            {
                return BadRequest();
            }


            try
            {
                data.Proveedores mapaAux = _mapper.Map<models.Proveedores, data.Proveedores>(Proveedores);
                //return mapaAux;
                new BE.Proveedores(_context).Update(mapaAux);

            }
            catch (Exception ee)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //private bool CategoriesExists(int id)
        //    {
        //        return ( new BE.BE.Proveedores(_context).GetOneById(id) != null);
        //    }

        // POST: api/Proveedores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Proveedores>> PostProveedores(models.Proveedores Proveedores)
        {
            try
            {
                data.Proveedores mapaAux = _mapper.Map<models.Proveedores, data.Proveedores>(Proveedores);
                new BE.Proveedores(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetProveedores", new { id = Proveedores.IdProveedor }, Proveedores); //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Proveedores>> DeleteProveedores(int id)
        {
            var Proveedores = new BE.Proveedores(_context).GetOneById(id);
            if (Proveedores == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Proveedores(_context).Delete(Proveedores);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.Proveedores mapaAux = _mapper.Map<data.Proveedores, models.Proveedores>(Proveedores);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Proveedores(_context).GetOneById(id) != null);
        }
    }
}