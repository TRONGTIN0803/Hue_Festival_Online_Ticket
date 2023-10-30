using Hue_Festival_Online_Ticket.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hue_Festival_Online_Ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiadiemController : ControllerBase
    {
        private readonly IDiadiemService _service;
        public DiadiemController(IDiadiemService service)
        {
            _service = service;
        }
        [HttpGet("get_menu_list")]
        public async Task<IActionResult> getMenuList()
        {
            return Ok(await _service.getMenuList());
        }

        [HttpGet("get_service_list")]
        public async Task<IActionResult>getServiceList(int submenu_id)
        {
            return Ok(await _service.getServiceList(submenu_id));
        }
    }
}
