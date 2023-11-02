using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface IChuongtrinhService
    {
        Task<KqJson> getProgramList(int type_program);
        Task<KqJson> getDetailProgram(int id_program);
        Task<KqJson> changeWishProgram(YeuthichRequestDTO model);
        Task<KqJson> getCarlenderList();
        Task<KqJson> getCarlenderProgramList(string date);
    }
}
