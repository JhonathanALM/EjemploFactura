using ApiFacturas.Context;
using ApiFacturas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFacturas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext context;
        public ClienteController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Cliente.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.Cliente.FirstOrDefault(x => x.ClienteId == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Cliente  cliente)
        {
            try
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                if(cliente.ClienteId == id)
                {
                    context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = cliente.ClienteId }, cliente);
                }
                else
                {
                    return BadRequest();
                }
             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cliente = context.Cliente.FirstOrDefault(x => x.ClienteId == id);
                if(cliente !=null)
                {
                    context.Remove(cliente);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
