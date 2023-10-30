using Hue_Festival_Online_Ticket.Model;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface IDiadiemService
    {
        Task<KqJson> getMenuList();
        Task<KqJson> getServiceList(int id_submenu);
    }
}
