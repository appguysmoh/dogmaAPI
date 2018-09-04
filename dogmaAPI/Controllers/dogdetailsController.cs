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
    public class dogdetailsController : ApiController
    {
        private dogmaEntities db = new dogmaEntities();

        // GET: api/dogdetails
        public IQueryable<dogdetail> Getdogdetails()
        {
            return db.dogdetails;
        }

        // GET: api/dogdetails/5
        [ResponseType(typeof(dogdetail))]
        public IHttpActionResult Getdogdetail(int id)
        {
            dogdetail dogdetail = db.dogdetails.Find(id);
            if (dogdetail == null)
            {
                return NotFound();
            }

            return Ok(dogdetail);
        }

        // PUT: api/dogdetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdogdetail(int id, dogdetail dogdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dogdetail.id)
            {
                return BadRequest();
            }

            db.Entry(dogdetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dogdetailExists(id))
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

        // POST: api/dogdetails
        [ResponseType(typeof(dogdetail))]
        public IHttpActionResult Postdogdetail(dogdetail dogdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dogdetails.Add(dogdetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dogdetail.id }, dogdetail);
        }

        // DELETE: api/dogdetails/5
        [ResponseType(typeof(dogdetail))]
        public IHttpActionResult Deletedogdetail(int id)
        {
            dogdetail dogdetail = db.dogdetails.Find(id);
            if (dogdetail == null)
            {
                return NotFound();
            }

            db.dogdetails.Remove(dogdetail);
            db.SaveChanges();

            return Ok(dogdetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dogdetailExists(int id)
        {
            return db.dogdetails.Count(e => e.id == id) > 0;
        }
    }
}