using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class DispositivosController : ApiController
    {
        private Hogar2Entities db = new Hogar2Entities();

        // GET: api/Dispositivos
        public IQueryable<Dispositivos> GetDispositivos()
        {
            return db.Dispositivos;
        }

        // GET: api/Dispositivos/5
        [ResponseType(typeof(Dispositivos))]
        public async Task<IHttpActionResult> GetDispositivos(long id)
        {
            Dispositivos dispositivos = await db.Dispositivos.FindAsync(id);
            if (dispositivos == null)
            {
                return NotFound();
            }

            return Ok(dispositivos);
        }

        // PUT: api/Dispositivos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDispositivos(long id, Dispositivos dispositivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dispositivos.id)
            {
                return BadRequest();
            }

            db.Entry(dispositivos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispositivosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Dispositivos
        [ResponseType(typeof(Dispositivos))]
        public async Task<IHttpActionResult> PostDispositivos(Dispositivos dispositivos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dispositivos.Add(dispositivos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dispositivos.id }, dispositivos);
        }

        // DELETE: api/Dispositivos/5
        [ResponseType(typeof(Dispositivos))]
        public async Task<IHttpActionResult> DeleteDispositivos(long id)
        {
            Dispositivos dispositivos = await db.Dispositivos.FindAsync(id);
            if (dispositivos == null)
            {
                return NotFound();
            }

            db.Dispositivos.Remove(dispositivos);
            await db.SaveChangesAsync();

            return Ok(dispositivos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DispositivosExists(long id)
        {
            return db.Dispositivos.Count(e => e.id == id) > 0;
        }
    }
}