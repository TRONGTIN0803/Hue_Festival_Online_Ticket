using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface IDiadiemService
    {
        Task<KqJson> getMenuList();
        Task<KqJson> getServiceList(int id_submenu);
        Task<KqJson> getServiceDetail(int id_diadiem);
        Task<KqJson> getTicketLocation();
        Task<KqJson> getPriceTicketProgram();
        Task<KqJson> changeWishDiadiem(YeuthichRequestDTO model);
        Task<KqJson> addVe(AddVeRequestDTO model);
        
    }
}
