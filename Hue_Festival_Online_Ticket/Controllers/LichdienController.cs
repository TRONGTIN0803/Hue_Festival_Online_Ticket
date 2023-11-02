using Hue_Festival_Online_Ticket.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hue_Festival_Online_Ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichdienController : ControllerBase
    {
        private readonly ILichdienService _lichdienService;
        public LichdienController(ILichdienService lichdienService)
        {
            _lichdienService = lichdienService;
        }

        //[HttpGet("get_carlender_list")]
        //public async Task<IActionResult> getCarlenderList()
        //{
        //    return Ok(await _lichdienService.getCarlenderList());
        //}

        //[HttpGet("get_carlender_program_list")]
        //public async Task<IActionResult>getcarlenderprogramlist(string date)
        //{
        //    return Ok(await _lichdienService.getCarlenderProgramList(date));
        //}
    }
}
