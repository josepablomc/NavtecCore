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
    public class GastosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public GastosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Gastos
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Gastos>>> GetGastos()
        {

            var res = new BE.Gastos(_context).GetAll();
            List<models.Gastos> mapaAux = _mapper.Map<IEnumerable<data.Gastos>, IEnumerable<models.Gastos>>(res).ToList();
            return mapaAux;
        }


        // GET: api/Gastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Gastos>> GetGastos(int id)
        {
            var Gastos = new BE.Gastos(_context).GetOneById(id);

            if (Gastos == null)
            {
                return NotFound();
            }
            models.Gastos mapaAux = _mapper.Map<data.Gastos, models.Gastos>(Gastos);
            return mapaAux;

        }

        // PUT: api/Gastos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGastos(int id, models.Gastos Gastos)
        {
            if (id != Gastos.IdGasto) //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
            {
                return BadRequest();
            }


            try
            {
                data.Gastos mapaAux = _mapper.Map<models.Gastos, data.Gastos>(Gastos);
                //return mapaAux;
                new BE.Gastos(_context).Update(mapaAux);

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
        //        return ( new BE.BE.Gastos(_context).GetOneById(id) != null);
        //    }

        // POST: api/Gastos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Gastos>> PostGastos(models.Gastos Gastos)
        {
            try
            {
                data.Gastos mapaAux = _mapper.Map<models.Gastos, data.Gastos>(Gastos);
                new BE.Gastos(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetGastos", new { id = Gastos.IdGasto }, Gastos); //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
        }

        // DELETE: api/Gastos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Gastos>> DeleteGastos(int id)
        {
            var Gastos = new BE.Gastos(_context).GetOneById(id);
            if (Gastos == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Gastos(_context).Delete(Gastos);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.Gastos mapaAux = _mapper.Map<data.Gastos, models.Gastos>(Gastos);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Gastos(_context).GetOneById(id) != null);
        }
    }
}