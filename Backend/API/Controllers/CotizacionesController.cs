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
    public class CotizacionesController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public CotizacionesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Cotizaciones
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Cotizaciones>>> GetCotizaciones()
        {

            var res = new BE.Cotizaciones(_context).GetAllAsync().Result;
            List<models.Cotizaciones> mapaAux = _mapper.Map<IEnumerable<data.Cotizaciones>, IEnumerable<models.Cotizaciones>>(res).ToList();
            return mapaAux;
        }


        // GET: api/Cotizaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Cotizaciones>> GetCotizaciones(int id)
        {
            var Cotizaciones = await new BE.Cotizaciones(_context).GetOneByIdAsync(id);
            var mapaAux = _mapper.Map<data.Cotizaciones, models.Cotizaciones>(Cotizaciones);

            if (Cotizaciones == null)
            {
                return NotFound();
            }

            return mapaAux;

        }

        // PUT: api/Cotizaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCotizaciones(int id, models.Cotizaciones Cotizaciones)
        {
            if (id != Cotizaciones.IdCotizacion) //Ojo validar el nombre del row que contiene el ID de la tabla en la DB
            {
                return BadRequest();
            }


            try
            {
                data.Cotizaciones mapaAux = _mapper.Map<models.Cotizaciones, data.Cotizaciones>(Cotizaciones);
                //return mapaAux;
                new BE.Cotizaciones(_context).Update(mapaAux);

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
        //        return ( new BE.BE.Cotizaciones(_context).GetOneById(id) != null);
        //    }

        // POST: api/Cotizaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Cotizaciones>> PostCotizaciones(models.Cotizaciones Cotizaciones)
        {
            try
            {
                data.Cotizaciones mapaAux = _mapper.Map<models.Cotizaciones, data.Cotizaciones>(Cotizaciones);
                new BE.Cotizaciones(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetCotizaciones", new { id = Cotizaciones.IdCotizacion}, Cotizaciones); //Ojo validar el nombre del row que contiene el ID de la tabla en la DB
        }

        // DELETE: api/Cotizaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Cotizaciones>> DeleteCotizaciones(int id)
        {
            var Cotizaciones = new BE.Cotizaciones(_context).GetOneById(id);
            if (Cotizaciones == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Cotizaciones(_context).Delete(Cotizaciones);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.Cotizaciones mapaAux = _mapper.Map<data.Cotizaciones, models.Cotizaciones>(Cotizaciones);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Cotizaciones(_context).GetOneById(id) != null);
        }
    }
}