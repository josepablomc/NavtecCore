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
    public class UsuariosController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public UsuariosController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Usuarios
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Usuarios>>> GetUsuarios()
        {

            var res = new BE.Usuarios(_context).GetAllAsync().Result;
            List<models.Usuarios> mapaAux = _mapper.Map<IEnumerable<data.Usuarios>, IEnumerable<models.Usuarios>>(res).ToList();
            return mapaAux;
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Usuarios>> GetUsuarios(int id)
        {
            var Usuarios = await new BE.Usuarios(_context).GetOneByIdAsync(id);
            var mapaAux = _mapper.Map<data.Usuarios, models.Usuarios>(Usuarios);

            if (Usuarios == null)
            {
                return NotFound();
            }
            return mapaAux;

        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, models.Usuarios Usuarios)
        {
            if (id != Usuarios.IdUsuario) //Ojo validar el nombre del row que contiene el ID de la tabla en la DB
            {
                return BadRequest();
            }


            try
            {
                data.Usuarios mapaAux = _mapper.Map<models.Usuarios, data.Usuarios>(Usuarios);
                //return mapaAux;
                new BE.Usuarios(_context).Update(mapaAux);

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
        //        return ( new BE.BE.Usuarios(_context).GetOneById(id) != null);
        //    }

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Usuarios>> PostUsuarios(models.Usuarios Usuarios)
        {
            try
            {
                data.Usuarios mapaAux = _mapper.Map<models.Usuarios, data.Usuarios>(Usuarios);
                new BE.Usuarios(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetUsuarios", new { id = Usuarios.IdUsuario }, Usuarios); //Ojo validar el nombre del row que contiene el ID de la tabla en la DB
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Usuarios>> DeleteUsuarios(int id)
        {
            var Usuarios = new BE.Usuarios(_context).GetOneById(id);
            if (Usuarios == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Usuarios(_context).Delete(Usuarios);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.Usuarios mapaAux = _mapper.Map<data.Usuarios, models.Usuarios>(Usuarios);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Usuarios(_context).GetOneById(id) != null);
        }
    }
}