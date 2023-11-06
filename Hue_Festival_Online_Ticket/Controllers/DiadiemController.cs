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

        [HttpPost("add_menu")]
        public async Task<IActionResult>addMenu(MenuRequestDTO model)
        {
            return Ok(await _service.addMenu(model));
        }

        [HttpPut("edit_menu")]
        public async Task<IActionResult> editMenu(MenuRequestDTO model)
        {
            return Ok(await _service.editMenu(model));
        }

        [HttpDelete("delete_menu")]
        public async Task<IActionResult>deleteMenu(DeleteEntityRequestDTO model)
        {
            return Ok(await _service.deleteMenu(model));
        }

        [HttpPost("add_submenu")]
        public async Task<IActionResult> addSubMenu(SubMenuRequestDTO model)
        {
            return Ok(await _service.addSubMenu(model));
        }

        [HttpPut("edit_submenu")]
        public async Task<IActionResult> editSubMenu(SubMenuRequestDTO model)
        {
            return Ok(await _service.editSubmenu(model));
        }

        [HttpDelete("delete_submenu")]
        public async Task<IActionResult> deleteSubMenu(DeleteEntityRequestDTO model)
        {
            return Ok(await _service.deleteSubMenu(model));
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

        [HttpPost("add_location")]
        public async Task<IActionResult>addLocation(DiadiemRequestDTO model)
        {
            return Ok(await _service.addDiadiem(model));
        }

        [HttpPut("edit_location")]
        public async Task<IActionResult>editLocatin(DiadiemRequestDTO model)
        {
            return Ok(await _service.editDiadiem(model));
        }

        [HttpDelete("delete_location")]
        public async Task<IActionResult> deleteLocation(DeleteEntityRequestDTO model)
        {
            return Ok(await _service.deleteDiadiem(model));
        }

    }
}
