using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Menu")]
    public class MenuDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_menu { get; set; }
        public string? Menu_title { get; set; }
        public string? PathIcon { get; set; }

        public virtual List<SubMenuDb>? list_Submenu { get; set; }
    }
}
