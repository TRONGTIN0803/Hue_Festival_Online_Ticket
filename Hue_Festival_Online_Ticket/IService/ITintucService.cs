using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface ITintucService
    {
        Task<KqJson> getNewsList();
        Task<KqJson> getNewsDetail(int news_id);
        Task<KqJson> changeWishTintuc(YeuthichRequestDTO model);
        Task<KqJson> addNews(TintucRequestDTO model);
        Task<KqJson> editNews(TintucRequestDTO model);
        Task<KqJson> deleteNews(DeleteEntityRequestDTO model);
        Task<KqJson> addImage(AddImageRequestDTO model);
    }
}
