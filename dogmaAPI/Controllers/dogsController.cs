using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using dogmaAPI;

namespace dogmaAPI.Controllers
{
    public class dogsController : ApiController
    {
        private dogmaEntities db = new dogmaEntities();

        // GET: api/dogs
        public IQueryable<dog> Getdogs()
        {
            return db.dogs;
        }

        // GET: api/dogs/5
        [ResponseType(typeof(dog))]
        public IHttpActionResult Getdog(int id)
        {
            dog dog = db.dogs.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // PUT: api/dogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdog(int id, dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dog.id)
            {
                return BadRequest();
            }

            db.Entry(dog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dogExists(id))
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

        // POST: api/dogs
        [ResponseType(typeof(dog))]
        public IHttpActionResult Postdog(dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dogs.Add(dog);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dog.id }, dog);
        }

        // DELETE: api/dogs/5
        [ResponseType(typeof(dog))]
        public IHttpActionResult Deletedog(int id)
        {
            dog dog = db.dogs.Find(id);
            if (dog == null)
            {
                return NotFound();
            }

            db.dogs.Remove(dog);
            db.SaveChanges();

            return Ok(dog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dogExists(int id)
        {
            return db.dogs.Count(e => e.id == id) > 0;
        }
    }
}