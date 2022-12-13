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
    public class VehiculoController : ControllerBase
    {
        //              contex de base
        private readonly AppDbContext context;
        //              contructor de la clase
        public VehiculoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblVehiculo.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetVehiculo")]
        public ActionResult Get(int id)
        {
            try
            {
                var cliente = context.tblVehiculo.FirstOrDefault(f => f.IdVehiculo == id);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Vehiculo cliente)
        {
            try
            {
                context.Add(cliente);
                context.SaveChanges();
                return CreatedAtRoute("GetVehiculo", new { id = cliente.IdVehiculo }, cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Vehiculo cliente)
        {
            try
            {
                if (cliente.IdVehiculo == id)
                {
                    context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAdmin", new { id = cliente.IdVehiculo }, cliente);
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
                Vehiculo clienteA = context.tblVehiculo.FirstOrDefault(f => f.IdVehiculo == id);
                if (clienteA != null)
                {
                    context.tblVehiculo.Remove(clienteA);
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
