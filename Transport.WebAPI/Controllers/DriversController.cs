using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Transport.Business.Abstract;
using Transport.Business.Concrete;
using Transport.Business.Models.Drivers;
using Transport.DataAccess;
using Transport.Entities.Concrete;
using Transport.Entities.DTOs;
using Transport.Entities.DTOs.DriversDTOs;

namespace Transport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController( IDriversService driversService) : ControllerBase
    {

        //DEFAULT CRUD 

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await driversService.GetAll());
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(GetDriversByIdRequest req)
        {
            var driver = await driversService.GetById(req);
            return Ok(driver);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DriversCreateDTO req)
        {
            await driversService.Add(req);
            return Ok("Sürücü başarıyla eklendi.");
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] DriversUpdateDTO updatedDriver)
        {
            await driversService.Update(updatedDriver.Id, updatedDriver);
            return Ok("Başarıyla güncellendi!");
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] Guid id)
        {
            await driversService.DeleteAsync(id);
            return NoContent();

        }

        //REQUEST - RESPONSE CRUD

        [HttpPost("GetByPhone")]
        public async Task<IActionResult> GetByPhone(GetDriversByPhoneRequest req)
        {
            var driver = await driversService.GetByPhone(req);

            return Ok(driver);
        }

        [HttpPost("GetByFullName")]
        public async Task<IActionResult> GetByFullName(GetDriversByFullNameRequest req)
        {
            var driver = await driversService.GetByFullName(req);

            return Ok(driver);
        }

        [HttpPost("GetByEmail")]
        public async Task<IActionResult> GetByEmail(GetDriversByEmailRequest req)
        {
            var driver = await driversService.GetByEmail(req);

            return Ok(driver);
        }
    }
}
