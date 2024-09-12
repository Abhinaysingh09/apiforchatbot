using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2;

namespace WebApplication2.Controllers
{
	public class questions_answersController : ApiController
	{
		private nbccEntities1 db = new nbccEntities1();

		// GET: api/questions_answers
		public IQueryable<questions_answers> Getquestions_answers()
		{
			return db.questions_answers;
		}

		// GET: api/questions_answers/5
		[ResponseType(typeof(questions_answers))]
		public IHttpActionResult Getquestions_answers(int id)
		{
			questions_answers questions_answers = db.questions_answers.Find(id);
			if (questions_answers == null)
			{
				return NotFound();
			}

			return Ok(questions_answers);
		}

		// PUT: api/questions_answers/5
		[ResponseType(typeof(void))]
		public IHttpActionResult Putquestions_answers(int id, questions_answers questions_answers)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != questions_answers.id)
			{
				return BadRequest();
			}

			db.Entry(questions_answers).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!questions_answersExists(id))
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

		// POST: api/questions_answers
		[ResponseType(typeof(questions_answers))]
		public IHttpActionResult Postquestions_answers(questions_answers questions_answers)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.questions_answers.Add(questions_answers);

			try
			{
				db.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				// Iterate through the validation errors
				foreach (var validationErrors in ex.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						// Log the validation error details
						System.Diagnostics.Debug.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
					}
				}
				// Optionally, return a more detailed error response here
				return BadRequest("Validation error occurred while saving the entity.");
			}

			return CreatedAtRoute("DefaultApi", new { id = questions_answers.id }, questions_answers);
		}

		// DELETE: api/questions_answers/5
		[ResponseType(typeof(questions_answers))]
		public IHttpActionResult Deletequestions_answers(int id)
		{
			questions_answers questions_answers = db.questions_answers.Find(id);
			if (questions_answers == null)
			{
				return NotFound();
			}

			db.questions_answers.Remove(questions_answers);
			db.SaveChanges();

			return Ok(questions_answers);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool questions_answersExists(int id)
		{
			return db.questions_answers.Count(e => e.id == id) > 0;
		}
	}
}
