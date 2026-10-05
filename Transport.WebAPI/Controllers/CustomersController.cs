using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Business.Models.Customers;
using Transport.Entities.DTOs.CustomersDTOs;

namespace Transport.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(
            ICustomersService customersService) : ControllerBase
    {

        //DEFAULT CRUD

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await customersService.GetAll());
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(GetCustomersByIdRequest id)
        {
            var result = await customersService.GetById(id);
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CustomersCreateDTO req)
        {
            try
            {
                Guid newCustomerId = await customersService.Add(req);
                return Ok(newCustomerId);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update/{id}")]
        public async Task Update(Guid id, [FromBody] CustomersUpdateDTO req)
        {
            await customersService.Update(id, req);
        }

        [HttpPost("Delete/{id}")] 
        public async Task Delete(Guid id)
        {
            await customersService.DeleteAsync(id);
        }

        //REQUEST - RESPONSE CRUD

        [HttpPost("GetByEmail")]
        public async Task<IActionResult> GetByEmail([FromBody] GetCustomersByEmailRequest req)
        {
            var result = await customersService.GetByEmail(req);
            return Ok(result);
        }

        [HttpPost("GetByPhone")]
        public async Task<IActionResult> GetByPhone([FromBody] GetCustomersByPhoneRequest req)
        {
            var result = await customersService.GetByPhone(req);
            return Ok(result);
        }

        [HttpPost("GetByFullName")]
        public async Task<IActionResult> GetByFullName([FromBody] GetCustomersByFullNameRequest req)
        {
            var result = await customersService.GetByFullName(req);
            return Ok(result);
        }
    }

    }
