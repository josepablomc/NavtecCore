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
    public class RolesController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public RolesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Roles
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Roles>>> GetRoles()
        {

            var res = new BE.Roles(_context).GetAll();
            List<models.Roles> mapaAux = _mapper.Map<IEnumerable<data.Roles>, IEnumerable<models.Roles>>(res).ToList();
            return mapaAux;
        }


        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Roles>> GetRoles(int id)
        {
            var Roles = new BE.Roles(_context).GetOneById(id);

            if (Roles == null)
            {
                return NotFound();
            }
            models.Roles mapaAux = _mapper.Map<data.Roles, models.Roles>(Roles);
            return mapaAux;

        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, models.Roles Roles)
        {
            if (id != Roles.IdRol) //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
            {
                return BadRequest();
            }


            try
            {
                data.Roles mapaAux = _mapper.Map<models.Roles, data.Roles>(Roles);
                //return mapaAux;
                new BE.Roles(_context).Update(mapaAux);

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
        //        return ( new BE.BE.Roles(_context).GetOneById(id) != null);
        //    }

        // POST: api/Roles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Roles>> PostRoles(models.Roles Roles)
        {
            try
            {
                data.Roles mapaAux = _mapper.Map<models.Roles, data.Roles>(Roles);
                new BE.Roles(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetRoles", new { id = Roles.IdRol }, Roles); //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Roles>> DeleteRoles(int id)
        {
            var Roles = new BE.Roles(_context).GetOneById(id);
            if (Roles == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Roles(_context).Delete(Roles);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.Roles mapaAux = _mapper.Map<data.Roles, models.Roles>(Roles);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Roles(_context).GetOneById(id) != null);
        }
    }
}