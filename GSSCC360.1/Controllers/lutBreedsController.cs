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
using GSSCC360._1;

namespace GSSCC360._1.Controllers
{
    public class lutBreedsController : ApiController
    {
        private GSSCC360_devEntities db = new GSSCC360_devEntities();

        // GET: api/lutBreeds
        public IQueryable<lutBreed> GetlutBreeds()
        {
            return db.lutBreeds;
        }

        // GET: api/lutBreeds/5
        [ResponseType(typeof(lutBreed))]
        public async Task<IHttpActionResult> GetlutBreed(int id)
        {
            lutBreed lutBreed = await db.lutBreeds.FindAsync(id);
            if (lutBreed == null)
            {
                return NotFound();
            }

            return Ok(lutBreed);
        }

        // PUT: api/lutBreeds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutlutBreed(int id, lutBreed lutBreed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lutBreed.Id)
            {
                return BadRequest();
            }

            db.Entry(lutBreed).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lutBreedExists(id))
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

        // POST: api/lutBreeds
        [ResponseType(typeof(lutBreed))]
        public async Task<IHttpActionResult> PostlutBreed(lutBreed lutBreed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.lutBreeds.Add(lutBreed);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lutBreed.Id }, lutBreed);
        }

        // DELETE: api/lutBreeds/5
        [ResponseType(typeof(lutBreed))]
        public async Task<IHttpActionResult> DeletelutBreed(int id)
        {
            lutBreed lutBreed = await db.lutBreeds.FindAsync(id);
            if (lutBreed == null)
            {
                return NotFound();
            }

            db.lutBreeds.Remove(lutBreed);
            await db.SaveChangesAsync();

            return Ok(lutBreed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool lutBreedExists(int id)
        {
            return db.lutBreeds.Count(e => e.Id == id) > 0;
        }
    }
}