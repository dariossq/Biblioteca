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
using WebApi01.Models;

namespace WebApi01.Controllers
{
    public class LibrosController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Libros
        public IQueryable<LIBRO> GetLIBROes()
        {
            return db.LIBROes;
        }

        // GET: api/Libros/5
        [ResponseType(typeof(LIBRO))]
        public async Task<IHttpActionResult> GetLIBRO(decimal id)
        {
            LIBRO lIBRO = await db.LIBROes.FindAsync(id);
            if (lIBRO == null)
            {
                return NotFound();
            }

            return Ok(lIBRO);
        }

        // PUT: api/Libros/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLIBRO(decimal id, LIBRO lIBRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lIBRO.ID_LIBRO)
            {
                return BadRequest();
            }

            db.Entry(lIBRO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LIBROExists(id))
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

        // POST: api/Libros
        [ResponseType(typeof(LIBRO))]
        public async Task<IHttpActionResult> PostLIBRO(LIBRO lIBRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LIBROes.Add(lIBRO);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LIBROExists(lIBRO.ID_LIBRO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lIBRO.ID_LIBRO }, lIBRO);
        }

        // DELETE: api/Libros/5
        [ResponseType(typeof(LIBRO))]
        public async Task<IHttpActionResult> DeleteLIBRO(decimal id)
        {
            LIBRO lIBRO = await db.LIBROes.FindAsync(id);
            if (lIBRO == null)
            {
                return NotFound();
            }

            db.LIBROes.Remove(lIBRO);
            await db.SaveChangesAsync();

            return Ok(lIBRO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LIBROExists(decimal id)
        {
            return db.LIBROes.Count(e => e.ID_LIBRO == id) > 0;
        }
    }
}