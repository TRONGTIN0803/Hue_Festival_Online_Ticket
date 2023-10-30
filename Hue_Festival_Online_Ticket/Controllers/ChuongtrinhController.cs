using Hue_Festival_Online_Ticket.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hue_Festival_Online_Ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuongtrinhController : ControllerBase
    {
        private readonly IChuongtrinhService _chuongtrinhService;
        public ChuongtrinhController(IChuongtrinhService chuongtrinhService)
        {
            _chuongtrinhService = chuongtrinhService;
        }

        [HttpGet("get_program_list")]
        public async Task<IActionResult>getProgramList(int type_program)
        {
            return Ok(await _chuongtrinhService.getProgramList(type_program));
        }

        [HttpGet("get_detail_program")]
        public async Task<IActionResult>getProgramDetail(int id_program)
        {
            return Ok(await _chuongtrinhService.getDetailProgram(id_program));
        }
    }
}
