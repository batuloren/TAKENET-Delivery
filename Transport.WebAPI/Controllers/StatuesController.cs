using Microsoft.AspNetCore.Mvc;
using Transport.Business.Abstract;
using Transport.Business.Models.Statuses;

namespace Transport.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StatusesController (IStatusesService statusesService) : ControllerBase
    {
        //DEFAULT CRUD

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await statusesService.GetAll();
            return Ok(result);
        }

        //RESPONSE REQUEST CRUD

        [HttpPost("GetByStatusCode")]
        public async Task<IActionResult> GetByStatusCode(GetStatusesByStatusCodeRequest req)
        {
            var result = await statusesService.GetByStatusCode(req);
                return Ok(result);
        }
    }
}
