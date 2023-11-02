using Hue_Festival_Online_Ticket.Data;

namespace Hue_Festival_Online_Ticket.Model.Response
{
    public class TintucResponeDTO
    {
        public int ID_tintuc { get; set; }
        public string? Tintuc_title { get; set; }
        public string? Tintuc_content { get; set; }
        public DateTime? Tintuc_time { get; set; }

        public virtual List<ChuongtrinhImageResponeDTO>? list_Image { get; set; }
    }
}
