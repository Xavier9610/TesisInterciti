using ApiWeb.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        //              contex de base
        private readonly AppDbContext context;
        //              contructor de la clase
        public ConductorController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblConductor.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetConductor")]
        public ActionResult Get(int id)
        {
            try
            {
                var cliente = context.tblConductor.FirstOrDefault(f => f.IdConductor == id);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Conductor cliente)
        {
            try
            {
                context.Add(cliente);
                context.SaveChanges();
                return CreatedAtRoute("GetConductor", new { id = cliente.IdConductor }, cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Admin cliente)
        {
            try
            {
                if (cliente.IdAdmin == id)
                {
                    context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetConductor", new { id = cliente.IdAdmin }, cliente);
                }
                else
                {
                    return BadRequest("Error al modificar");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var clienteA = context.tblConductor.FirstOrDefault(f => f.IdConductor == id);
                if (clienteA != null)
                {
                    context.tblConductor.Remove(clienteA);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest("Error al modificar");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
