using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Submenu")]
    public class SubMenuDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_submenu { get; set; }
        public string? Submenu_title { get; set; }
        public string? PathIcon { get; set; }
        public int? Menu_id { get; set; }

        public virtual MenuDb? Menu { get; set; }
        public virtual List<DiaDiemDb>? list_Diadiem { get; set; }
    }
}
