using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Business.Models.Vehicles;
using Transport.Entities.DTOs.VehiclesDTOs;

namespace Transport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController( IVehiclesService vehiclesService) : ControllerBase
    {
        //DEFAULT CRUD

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await vehiclesService.GetAll();
            return Ok(result);
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(GetVehiclesByIdRequest req)
        {
            var result = await vehiclesService.GetById(req);
            return Ok(result); // null bile olsa JSON gider
        }

        [HttpPost("Add")]
        public async Task Add(VehiclesCreateDTO req)
        {
            await vehiclesService.Add(req);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] VehiclesUpdateDTO updatedVehicle)
        {
            await vehiclesService.Update(updatedVehicle);
            return Ok("Başarıyla güncellendi!");
        }

        [HttpPost("Delete")]
        public async Task Delete([FromBody] Guid id)
        {
            await vehiclesService.DeleteAsync(id);
        }

        //REQUEST - RESPONSE CRUD

        [HttpPost("GetByCarModel")]
        public async Task<IActionResult> GetByCarModel(GetVehiclesByCarModelRequest req)
        {
            var result = await vehiclesService.GetByCarModel(req);
            return Ok(result);
        }

        [HttpPost("GetByPlateNumber")]
        public async Task<IActionResult> GetByPlateNumber(GetVehiclesByPlateNumberRequest req)
        {
            var result = await vehiclesService.GetByPlateNumber(req);
            return Ok(result);
        }

    }
        
}
