using CalendarDataBase;
using CalendarModel;
using CalendarModel.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private PersonData _db;

        public PersonController(PersonData db)
        {

            this._db = db;

        }

        // GET: api/controller																					
        [HttpGet("All")]
        public IActionResult Get(string token)
        {


            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                var retorno = this._db.GetAllPersons();

                return Json(retorno);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, string token)
        {


            // Validate Token																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                // Operação de Consulta																				
                var retorno = this._db.GetPersonById(id);

                return Json(retorno);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }      

        // POST api/controller																						
        [HttpPost]
        public IActionResult Post(Person person, string token)
        {

            // Valid Parameters																			
            if (person == null)
            {
                return BadRequest("Invalid Person");
            }

            
            if (!person.IsValidPerson().IsValid)
            {
                return BadRequest(person.IsValidPerson().Message);
            }


            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                person.CreatedDate = DateTime.Now;
                person.LastModifiedDate = DateTime.Now;
                person.IsDeleted = false;
                person.Active = true;

                var retorno = this._db.InsertPerson(person);

                return Json(retorno);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);

            }


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Person person, string token)
        {

            // Valid Parameters																			
            if (person == null)
            {
                return BadRequest("Invalid parameter.");
            }

            // Valid Ids																	
            if (id != person.PersonId)
            {
                return BadRequest("Invalid Id...");
            }

            if (!person.IsValidPerson().IsValid)
            {
                return BadRequest(person.IsValidPerson().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                person.LastModifiedDate = DateTime.Now;
                person.IsDeleted = false;

                var result = this._db.UpdatePerson(person);

                if (result != "Ok")
                {
                    return StatusCode(500, result);
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        // DELETE api/controller/5																					
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Person person, string token)
        {

            // Valid Parameters																			
            if (person == null)
            {
                return BadRequest("Parâmetro(s) ausente(s).");
            }

            // Valid Ids																	
            if (id != person.PersonId)
            {
                return BadRequest("Invalid Id...");
            }

            if (!person.IsValidPerson().IsValid)
            {
                return BadRequest(person.IsValidPerson().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }


            try
            {

                person.LastModifiedDate = DateTime.Now;
                person.IsDeleted = true;

                var retorno = this._db.DeletePerson(person);

                if (retorno != "Ok")
                {
                    return StatusCode(500, retorno);
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
