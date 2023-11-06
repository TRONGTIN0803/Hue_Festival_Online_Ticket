using AutoMapper;
using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface IUserService
    {
        Task<KqJson> getAboutList();
        Task<KqJson> getAboutDetail(int about_id);
        Task<KqJson> get_wish_program_list(int userId);
        Task<KqJson> get_wish_tintuc_list(int userId);
        Task<KqJson> get_wish_diadiem_list(int userId);
        Task<KqJson> loginUser(DangNhapRequestDTO model);
        Task<KqJson> register(DangkyRequestDTO model);
        Task<KqJson> bookTicketHistory(int user_id);
        Task<ResultCheckinTicket> historyCheckInTicketlist(int user_id, string date, int type, int chuongtrinh_id);
        Task<KqJson> changePassword(ChangePasswordRequestDTO model);
        Task<KqJson> resetPassword(ResetPasswordRequestDTO model);
    }
}
