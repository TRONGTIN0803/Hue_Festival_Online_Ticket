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
        Task<KqJson> addMenu(MenuRequestDTO model);
        Task<KqJson> editMenu(MenuRequestDTO model);
        Task<KqJson> deleteMenu(DeleteEntityRequestDTO model);
        Task<KqJson>addSubMenu(SubMenuRequestDTO model);
        Task<KqJson> editSubmenu(SubMenuRequestDTO model);
        Task<KqJson> deleteSubMenu(DeleteEntityRequestDTO model);
        Task<KqJson> addDiadiem(DiadiemRequestDTO model);
        Task <KqJson> editDiadiem(DiadiemRequestDTO model);
        Task<KqJson> deleteDiadiem(DeleteEntityRequestDTO model);
        
    }
}
