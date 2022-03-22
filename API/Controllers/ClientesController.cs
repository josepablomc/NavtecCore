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

    public class ClientesController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public ClientesController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.Clientes>>> GetClientes()
        {

            var res = new BE.Clientes(_context).GetAll();
            List<models.Clientes> mapaAux = _mapper.Map<IEnumerable<data.Clientes>, IEnumerable<models.Clientes>>(res).ToList();
            return mapaAux;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<models.Clientes>> GetClientes(int id)
        {
            var Clientes = new BE.Clientes(_context).GetOneById(id);

            if (Clientes == null)
            {
                return NotFound();
            }
            models.Clientes mapaAux = _mapper.Map<data.Clientes, models.Clientes>(Clientes);
            return mapaAux;

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientes(int id, models.Clientes Clientes)
        {
            if (id != Clientes.IdCliente) //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
            {
                return BadRequest();
            }


            try
            {
                data.Clientes mapaAux = _mapper.Map<models.Clientes, data.Clientes>(Clientes);
                //return mapaAux;
                new BE.Clientes(_context).Update(mapaAux);

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
        public async Task<ActionResult<models.Clientes>> PostClientes(models.Clientes Clientes)
        {
            try
            {
                data.Clientes mapaAux = _mapper.Map<models.Clientes, data.Clientes>(Clientes);
                new BE.Clientes(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetClientes", new { id = Clientes.IdCliente }, Clientes); //OJO que sea el mismo nombre de la columna ID de la DB --Karen 19/03/2022
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Clientes>> DeleteClientes(int id)
        {
            var Clientes = new BE.Clientes(_context).GetOneById(id);
            if (Clientes == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Clientes(_context).Delete(Clientes);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.Clientes mapaAux = _mapper.Map<data.Clientes, models.Clientes>(Clientes);
            return mapaAux;
        }

        private bool Exists(int id)
        {
            return (new BE.Clientes(_context).GetOneById(id) != null);
        }
    }
}
