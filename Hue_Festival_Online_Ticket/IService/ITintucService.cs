using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface ITintucService
    {
        Task<KqJson> getNewsList();
        Task<KqJson> getNewsDetail(int news_id);
        Task<KqJson> changeWishTintuc(YeuthichRequestDTO model);
    }
}
