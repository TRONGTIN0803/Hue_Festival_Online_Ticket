using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hue_Festival_Online_Ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("hotro/get_about_list")]
        public async Task<IActionResult> getAboutList()
        {
            return Ok(await _userService.getAboutList());
        }

        [HttpGet("hotro/get_about_detail")]
        public async Task<IActionResult>getAboutDetail(int about_id)
        {
            return Ok(await _userService.getAboutDetail(about_id));
        }

        [HttpGet("yeuthich/get_wish_program_list")]
        public async Task<IActionResult>getWishProgramList(int user_id)
        {
            return Ok(await _userService.get_wish_program_list(user_id));
        }
        [HttpGet("yeuthich/get_wish_diadiem_list")]
        public async Task<IActionResult> getWishDiadiemList(int user_id)
        {
            return Ok(await _userService.get_wish_diadiem_list(user_id));
        }
        [HttpGet("yeuthich/get_wish_news_list")]
        public async Task<IActionResult> getWishNewsList(int user_id)
        {
            return Ok(await _userService.get_wish_tintuc_list(user_id));
        }

        [HttpGet("ticket/history_booking")]
        public async Task<IActionResult>historyBooking(int user_id)
        {
            return Ok(await _userService.bookTicketHistory(user_id));
        }

        [HttpGet("ticket/hostory_checkin_list")]
        public async Task<IActionResult>historyCheckInList(int user_id)
        {
            return Ok(await _userService.historyCheckInTicketlist(user_id));
        }

        [HttpPost("login")]
        public async Task<IActionResult>login(DangNhapRequestDTO model)
        {
            return Ok(await _userService.loginUser(model));
        }

        [HttpPost("register")]
        public async Task<IActionResult>register(DangkyRequestDTO model)
        {
            return Ok(await _userService.register(model));
        }
    }
}
