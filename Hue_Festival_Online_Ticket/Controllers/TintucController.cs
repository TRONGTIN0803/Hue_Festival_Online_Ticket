using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hue_Festival_Online_Ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TintucController : ControllerBase
    {
        private ITintucService _tintucService;
        public TintucController(ITintucService tintucService)
        {
            _tintucService = tintucService;
        }

        [HttpGet("get_news_list")]
        public async Task<IActionResult> getNewsList()
        {
            return Ok(await _tintucService.getNewsList());
        }

        [HttpGet("get_news_detail")]
        public async Task<IActionResult>getNewsDetail(int news_id)
        {
            return Ok(await _tintucService.getNewsDetail(news_id));
        }

        [HttpPost("change_wish_tintuc")]
        public async Task<IActionResult>changeWishTintuc(YeuthichRequestDTO model)
        {
            return Ok(await _tintucService.changeWishTintuc(model));
        }

        [HttpPost("add_news")]
        public async Task<IActionResult>addNews(TintucRequestDTO model)
        {
            return Ok(await _tintucService.addNews(model));
        }

        [HttpPut("edit_news")]
        public async Task<IActionResult>editNews(TintucRequestDTO model)
        {
            return Ok(await _tintucService.editNews(model));
        }

        [HttpDelete("delete_news")]
        public async Task<IActionResult>deleteNews(DeleteEntityRequestDTO model)
        {
            return Ok(await _tintucService.deleteNews(model));
        }
        [HttpPost("add_image")]
        public async Task<IActionResult>addImage(AddImageRequestDTO model)
        {
            return Ok(await _tintucService.addImage(model));
        }
    }
}
