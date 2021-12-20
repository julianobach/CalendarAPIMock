using CalendarDataBase;
using CalendarModel.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalendarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : Controller
    {
        private SlotsData _db;

        public SlotsController(SlotsData db)
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

                var retorno = this._db.GetAllSlots();

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


            // Validação do token																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                // Operação de Consulta																				
                var retorno = this._db.GetSlotById(id);

                return Json(retorno);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("ByPersonId")]
        public IActionResult GetByPersonId(int id, string token)
        {


            // Validação do token																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                // Operação de Consulta																				
                var retorno = this._db.GetSlotsByPersonId(id);

                return Json(retorno);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/controller																						
        [HttpPost]
        public IActionResult Post(Slot slot, string token)
        {

            // Valid Parameters																			
            if (slot == null)
            {
                return BadRequest("Invalid Slot");
            }

            if (!slot.IsValidSlot().IsValid)
            {
                return BadRequest(slot.IsValidSlot().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                slot.CreatedDate = DateTime.Now;
                slot.LastModifiedDate = DateTime.Now;
                slot.IsDeleted = false;
                slot.Active = true;

                var retorno = this._db.InsertSlot(slot);

                return Json(retorno);

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);

            }


        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Slot slot, string token)
        {

            // Valid Parameters																			
            if (slot == null)
            {
                return BadRequest("Invalid parameter.");
            }

            // Valid Ids																	
            if (id != slot.SlotID)
            {
                return BadRequest("Invalid Id...");
            }

            if (!slot.IsValidSlot().IsValid)
            {
                return BadRequest(slot.IsValidSlot().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            try
            {

                slot.LastModifiedDate = DateTime.Now;
                slot.IsDeleted = false;

                var retorno = this._db.UpdateSlot(slot);

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

        // DELETE api/controller/5																					
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Slot slot, string token)
        {

            // Valid Parameters																			
            if (slot == null)
            {
                return BadRequest("Parâmetro(s) ausente(s).");
            }

            // Valid Ids																	
            if (id != slot.SlotID)
            {
                return BadRequest("Invalid Id...");
            }

            if (!slot.IsValidSlot().IsValid)
            {
                return BadRequest(slot.IsValidSlot().Message);
            }

            // token validate																						
            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }


            try
            {

                slot.LastModifiedDate = DateTime.Now;
                slot.IsDeleted = true;

                var retorno = this._db.DeleteSlot(slot);

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
