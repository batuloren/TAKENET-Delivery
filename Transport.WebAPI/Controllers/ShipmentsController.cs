using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Business.Models.Shipments;
using Transport.DataAccess;
using Transport.Entities.DTOs.ShipmentsDTOs;

namespace Transport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController(IShipmentsService shipmentsService) : ControllerBase
    {

        //ADMIN
        [HttpGet("Table_CP")]
        public async Task<IActionResult> GetAllShipments()
        {
            var result = await shipmentsService.GetAllShipments();
            return Ok(result);
        }

        [HttpGet("All_CP")]
        public async Task<IActionResult> GetAll()
        {
            var result = await shipmentsService.GetAllAdmin();
            return Ok(result);
        }

        [HttpGet("GetById_CP/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await shipmentsService.GetById(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ShipmentsCreateDTO req)
        {
            string trackId = await shipmentsService.Add(req);
            return Ok(trackId);
            
        }
        [HttpPost("Update_CP")]
        public async Task Update([FromBody] ShipmentsUpdateDTO req)
        {
            await shipmentsService.Update(req.Id, req);
        }
        [HttpPost("Delete_CP")]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            await shipmentsService.Delete(id);
            return Ok("Deleted");
        }

        [HttpPost("GetByCustomerEmail_CP")]
        public async Task<IActionResult> GetByCustomerEmail(GetShipmentsByCustomerEmailRequest req)
        {
            var result = await shipmentsService.GetByCustomerEmail(req);
            if (result == null) { throw new Exception("Bulunamadı!"); }
            return Ok(result);
        }

        //USER 
        
        [HttpPost("GetByTrackId_UP")]
        public async Task<IActionResult> GetByTrackId(GetShipmentsByTrackIdRequest req)
        {
            var result = await shipmentsService.GetByTrackId(req);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
    }
}
