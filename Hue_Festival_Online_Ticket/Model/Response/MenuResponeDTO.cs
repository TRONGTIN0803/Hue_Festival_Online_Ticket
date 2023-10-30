using Hue_Festival_Online_Ticket.Data;

namespace Hue_Festival_Online_Ticket.Model.Response
{
    public class MenuResponeDTO
    {
        public int ID_menu { get; set; }
        public string? Menu_title { get; set; }
        public string? PathIcon { get; set; }

        public virtual List<SubMenuResponeDTO>? list_Submenu { get; set; }
    }
}
