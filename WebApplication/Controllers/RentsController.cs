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
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RentsController : ApiController
    {
        private WebApplicationContext db = new WebApplicationContext();

        // GET: api/Rents
        public IQueryable<Rent> GetRents()
        {
            return db.Rents.Include("Client.Country").Include("Material.Category");
        }

        // GET: api/Rents/5
        [ResponseType(typeof(Rent))]
        public IHttpActionResult GetRent(int id)
        {
            Rent rent = db.Rents.Include("Client.Country").Include("Material.Category").FirstOrDefault(p => p.Id == id);
            if (rent == null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        [HttpPut]
        // PUT: api/Rents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRent(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(rent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rents
        [ResponseType(typeof(Rent))]
        public IHttpActionResult PostRent(Rent rent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Materials.Attach(rent.Material);
            db.Clients.Attach(rent.Client);
            db.Rents.Add(rent);
            Material material = db.Materials.Find(rent.Material.Id);
            material.Amount--;
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rent.Id }, rent); 
        }

        // DELETE: api/Rents/5
        [ResponseType(typeof(Rent))]
        public IHttpActionResult DeleteRent(int id)
        {
            var q = from r in db.Rents.Include("Material").Where(s => s.Id == id)
                    select r;

            Rent rent = q.First();

            if (rent == null)
            {
                return NotFound();
            }


            Material m = db.Materials.Find(rent.Material.Id);
            m.Amount++;
            db.Rents.Remove(rent);
            db.SaveChanges();

            return Ok(rent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentExists(int id)
        {
            return db.Rents.Count(e => e.Id == id) > 0;
        }
    }
}