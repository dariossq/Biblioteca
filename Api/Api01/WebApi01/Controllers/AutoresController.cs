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
    public class AutoresController : ApiController
    {
        private Entities db = new Entities();
       
        // GET: api/Autores
        public IQueryable<AUTOR> GetAUTORs()
        {
           return db.AUTORs;
        }

        // GET: api/Autores/5
        [ResponseType(typeof(AUTOR))]
        public async Task<IHttpActionResult> GetAUTOR(decimal id)
        {
            AUTOR aUTOR = await db.AUTORs.FindAsync(id);
            if (aUTOR == null)
            {
                return NotFound();
            }

            return Ok(aUTOR);
        }

        // PUT: api/Autores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAUTOR(decimal id, AUTOR aUTOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aUTOR.ID_AUTOR)
            {
                return BadRequest();
            }

            db.Entry(aUTOR).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AUTORExists(id))
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

        // POST: api/Autores
        [ResponseType(typeof(AUTOR))]
        public async Task<IHttpActionResult> PostAUTOR(AUTOR aUTOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AUTORs.Add(aUTOR);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AUTORExists(aUTOR.ID_AUTOR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aUTOR.ID_AUTOR }, aUTOR);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(AUTOR))]
        public async Task<IHttpActionResult> DeleteAUTOR(decimal id)
        {
            AUTOR aUTOR = await db.AUTORs.FindAsync(id);
            if (aUTOR == null)
            {
                return NotFound();
            }

            db.AUTORs.Remove(aUTOR);
            await db.SaveChangesAsync();

            return Ok(aUTOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AUTORExists(decimal id)
        {
            return db.AUTORs.Count(e => e.ID_AUTOR == id) > 0;
        }
    }
}