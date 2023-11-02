using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface IQuanlyService
    {
        Task<KqJson> loginAdmin(DangNhapRequestDTO model);
        Task<KqJson> checkInfoTicket(int ve_id);
        Task<KqJson> checkInTicket(CheckInTicketRequestDTO model);
        Task<KqJson> historyCheckInTicketList(int nguoisoat_id);
        Task<KqJson> getThongkeTicket(string date, int type, int chuongtrinh_id);
    }
}
