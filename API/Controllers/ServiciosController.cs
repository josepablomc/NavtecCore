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
    public class ServiciosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ServiciosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Servicios
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Servicios>>> GetServicios()
        {

            var res = new BE.Servicios(_context).GetAll();
            List<models.Servicios> mapaAux = _mapper.Map<IEnumerable<data.Servicios>, IEnumerable<models.Servicios>>(res).ToList();
            return mapaAux;
        }


        // GET: api/Servicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Servicios>> GetServicios(int id)
        {
            var Servicios = new BE.Servicios(_context).GetOneById(id);

            if (Servicios == null)
            {
                return NotFound();
            }
            models.Servicios mapaAux = _mapper.Map<data.Servicios, models.Servicios>(Servicios);
            return mapaAux;

        }

        // PUT: api/Servicios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicios(int id, models.Servicios Servicios)
        {
            if (id != Servicios.IdServicio) //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
            {
                return BadRequest();
            }


            try
            {
                data.Servicios mapaAux = _mapper.Map<models.Servicios, data.Servicios>(Servicios);
                //return mapaAux;
                new BE.Servicios(_context).Update(mapaAux);

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
        //        return ( new BE.BE.Servicios(_context).GetOneById(id) != null);
        //    }

        // POST: api/Servicios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Servicios>> PostServicios(models.Servicios Servicios)
        {
            try
            {
                data.Servicios mapaAux = _mapper.Map<models.Servicios, data.Servicios>(Servicios);
                new BE.Servicios(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetServicios", new { id = Servicios.IdServicio }, Servicios); //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
        }

        // DELETE: api/Servicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Servicios>> DeleteServicios(int id)
        {
            var Servicios = new BE.Servicios(_context).GetOneById(id);
            if (Servicios == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Servicios(_context).Delete(Servicios);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.Servicios mapaAux = _mapper.Map<data.Servicios, models.Servicios>(Servicios);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Servicios(_context).GetOneById(id) != null);
        }
    }
}