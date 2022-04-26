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
    public class EmpresasController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public EmpresasController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Empresas
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Empresas>>> GetEmpresas()
        {

            var res = new BE.Empresas(_context).GetAllAsync().Result;
            List<models.Empresas> mapaAux = _mapper.Map<IEnumerable<data.Empresas>, IEnumerable<models.Empresas>>(res).ToList();
            return mapaAux;
        }


        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Empresas>> GetEmpresas(int id)
        {
            var Empresas = await new BE.Empresas(_context).GetOneByIdAsync(id);
            var mapaAux = _mapper.Map<data.Empresas, models.Empresas>(Empresas);

            if (Empresas == null)
            {
                return NotFound();
            }
            return mapaAux;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresas(int id, models.Empresas Empresas)
        {
            if (id != Empresas.IdEmpresa) 
            {
                return BadRequest();
            }


            try
            {
                data.Empresas mapaAux = _mapper.Map<models.Empresas, data.Empresas>(Empresas);

                new BE.Empresas(_context).Update(mapaAux);

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

        [HttpPost]
        public async Task<ActionResult<models.Empresas>> PostEmpresas(models.Empresas Empresas)
        {
            try
            {
                data.Empresas mapaAux = _mapper.Map<models.Empresas, data.Empresas>(Empresas);
                new BE.Empresas(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetEmpresas", new { id = Empresas.IdEmpresa }, Empresas); //Ojo validar el nombre del row que contiene el ID de la tabla en la DB
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Empresas>> DeleteEmpresas(int id)
        {
            var Empresas = new BE.Empresas(_context).GetOneById(id);
            if (Empresas == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Empresas(_context).Delete(Empresas);
            }
            catch (Exception)
            {

                BadRequest();
            }
            models.Empresas mapaAux = _mapper.Map<data.Empresas, models.Empresas>(Empresas);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Empresas(_context).GetOneById(id) != null);
        }
    }
}
