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
using WebApplication2;

namespace WebApplication2.Controllers
{
	public class fieldsController : ApiController
	{
		private nbccEntities1 db = new nbccEntities1();

		// GET: api/fields
		public IQueryable<field> Getfields()
		{
			return db.fields;
		}

		// GET: api/fields/5
		[ResponseType(typeof(field))]
		public IHttpActionResult Getfield(int id)
		{
			field field = db.fields.Find(id);
			if (field == null)
			{
				return NotFound();
			}

			return Ok(field);
		}

		// PUT: api/fields/5
		[ResponseType(typeof(void))]
		public IHttpActionResult Putfield(int id, field field)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != field.id)
			{
				return BadRequest();
			}

			db.Entry(field).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!fieldExists(id))
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

		// POST: api/fields
		[ResponseType(typeof(field))]
		public IHttpActionResult Postfield(field field)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.fields.Add(field);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = field.id }, field);
		}

		// DELETE: api/fields/5
		[ResponseType(typeof(field))]
		public IHttpActionResult Deletefield(int id)
		{
			field field = db.fields.Find(id);
			if (field == null)
			{
				return NotFound();
			}

			db.fields.Remove(field);
			db.SaveChanges();

			return Ok(field);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool fieldExists(int id)
		{
			return db.fields.Count(e => e.id == id) > 0;
		}
	}
}
