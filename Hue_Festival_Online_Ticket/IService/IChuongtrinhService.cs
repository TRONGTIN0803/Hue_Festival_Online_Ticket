using Hue_Festival_Online_Ticket.Model;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface IChuongtrinhService
    {
        Task<KqJson> getProgramList(int type_program);
        Task<KqJson> getDetailProgram(int id_program);
    }
}
