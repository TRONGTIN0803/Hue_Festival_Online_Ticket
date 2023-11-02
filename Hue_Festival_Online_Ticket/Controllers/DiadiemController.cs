using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model.Request;
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

        [HttpGet("get_service_detail")]
        public async Task<IActionResult>getServiceDetail(int id_diadiem)
        {
            return Ok(await _service.getServiceDetail(id_diadiem));
        }

        [HttpGet("banve/get_ticket_location")]
        public async Task<IActionResult> getTicketLocatin()
        {
            return Ok(await _service.getTicketLocation());
        }

        [HttpGet("giave/get_price_ticket_program")]
        public async Task<IActionResult> getPriceTicketProgram()
        {
            return Ok(await _service.getPriceTicketProgram());
        }

        [HttpPost("change_wish_diadiem")]
        public async Task<IActionResult>changeWishDiadiemm(YeuthichRequestDTO model)
        {
            return Ok(await _service.changeWishDiadiem(model));
        }

        [HttpPost("banve/buy_ticket")]
        public async Task<IActionResult>buyTicket(AddVeRequestDTO model)
        {
            return Ok(await _service.addVe(model));
        }

    }
}
