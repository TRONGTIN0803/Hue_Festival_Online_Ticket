using Hue_Festival_Online_Ticket.Model;

namespace Hue_Festival_Online_Ticket.IService
{
    public interface ILichdienService
    {
        Task<KqJson> getCarlenderList();
        Task<KqJson> getCarlenderProgramList(string date);
    }
}
