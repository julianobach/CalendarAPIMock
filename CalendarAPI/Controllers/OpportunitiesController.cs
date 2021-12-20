using CalendarDataBase;
using CalendarModel.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunitiesController : Controller
    {
        private OpportunityData _db;

        public OpportunitiesController(OpportunityData db)
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

                var retorno = this._db.GetAllOpportunitys();

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
                var retorno = this._db.GetOpportunityById(id);

                return Json(retorno);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/controller																						
        [HttpPost]
        public IActionResult Post(Opportunity opportunity, string token)
        {

            // Valid Parameters																			
            if (opportunity == null)
            {
                return BadRequest("Invalid Opportunity");
            }

            if (!opportunity.IsValidOpportunity().IsValid)
            {
                return BadRequest(opportunity.IsValidOpportunity().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {
                opportunity.CreatedDate = DateTime.Now;
                opportunity.LastModifiedDate = DateTime.Now;
                opportunity.IsDeleted = false;
                opportunity.Active = true;

                // Operação de Inserção																				
                var retorno = this._db.InsertOpportunity(opportunity);

                return Json(retorno);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);

            }


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Opportunity opportunity, string token)
        {

            // Valid Parameters																			
            if (opportunity == null)
            {
                return BadRequest("Invalid parameter.");
            }

            // Valid Ids																	
            if (id != opportunity.OpportunityId)
            {
                return BadRequest("Invalid Id...");
            }

            if (!opportunity.IsValidOpportunity().IsValid)
            {
                return BadRequest(opportunity.IsValidOpportunity().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                opportunity.LastModifiedDate = DateTime.Now;
                opportunity.IsDeleted = false;

                var result = this._db.UpdateOpportunity(opportunity);

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
        public IActionResult Delete(int id, Opportunity opportunity, string token)
        {

            // Valid Parameters																			
            if (opportunity == null)
            {
                return BadRequest("Parâmetro(s) ausente(s).");
            }

            // Valid Ids																	
            if (id != opportunity.OpportunityId)
            {
                return BadRequest("Invalid Id...");
            }

            if (!opportunity.IsValidOpportunity().IsValid)
            {
                return BadRequest(opportunity.IsValidOpportunity().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }


            try
            {

                opportunity.LastModifiedDate = DateTime.Now;
                opportunity.IsDeleted = true;

                var retorno = this._db.DeleteOpportunity(opportunity);

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
