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
    public class RecorridoMensajeController : ControllerBase
    {
        //              contex de base
        private readonly AppDbContext context;
        //              contructor de la clase
        public RecorridoMensajeController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.tblRecorridoMensaje.ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetRecorridoMensaje")]
        public ActionResult Get(int id)
        {
            try
            {
                var cliente = context.tblRecorridoMensaje.FirstOrDefault(f => f.IdRecorridoMensaje == id);
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] RecorridoMensaje cliente)
        {
            try
            {
                context.Add(cliente);
                context.SaveChanges();
                return CreatedAtRoute("GetRecorridoMensaje", new { id = cliente.IdRecorridoMensaje }, cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RecorridoMensaje cliente)
        {
            try
            {
                if (cliente.IdRecorridoMensaje == id)
                {
                    context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetRecorridoMensaje", new { id = cliente.IdRecorridoMensaje }, cliente);
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
                var clienteA = context.tblRecorridoMensaje.FirstOrDefault(f => f.IdRecorridoMensaje == id);
                if (clienteA != null)
                {
                    context.tblRecorridoMensaje.Remove(clienteA);
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
