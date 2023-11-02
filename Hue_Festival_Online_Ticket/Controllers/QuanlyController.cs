using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hue_Festival_Online_Ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanlyController : ControllerBase
    {
        private readonly IQuanlyService _soatveService;
        public QuanlyController(IQuanlyService soatveService)
        {
            _soatveService = soatveService;
        }

        [HttpPost("login_admin")]
        public async Task<IActionResult>loginAdmin(DangNhapRequestDTO model)
        {
            return Ok(await _soatveService.loginAdmin(model));
        }

        [HttpGet("check_info_ticket")]
        public async Task<IActionResult>checkInfoTicket(int ve_id)
        {
            return Ok(await _soatveService.checkInfoTicket(ve_id));
        }

        [HttpPut("check_in_ticket")]
        public async Task<IActionResult> checkInTicket(CheckInTicketRequestDTO model)
        {
            return Ok(await _soatveService.checkInTicket(model));
        }

        [HttpGet("history_ticket_checkin_list")]
        public async Task<IActionResult>historyTicketCheckInList(int nvsoatve_id)
        {
            return Ok(await _soatveService.historyCheckInTicketList(nvsoatve_id));
        }

        [HttpGet("get_thongke_ticket_list")]
        public async Task<IActionResult>getThongkeTicketList(string date, int type,int chuongtrinh_id)
        {
            return Ok(await _soatveService.getThongkeTicket(date, type, chuongtrinh_id));
        }
    }
}
