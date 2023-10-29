using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Hotro")]
    public class HoTroDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_hotro { get; set; }
        public string? Hotro_title { get; set; }
        public string? Hotro_content { get; set; }

        public virtual List<HoTroUserDb>? list_HotroUser { get; set; }
    }
}
