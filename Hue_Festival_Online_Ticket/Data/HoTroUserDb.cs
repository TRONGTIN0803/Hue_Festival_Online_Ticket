using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("HotroUser")]
    public class HoTroUserDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_hotro_user { get; set; }
        public int? User_id { get; set; }
        public int? Hotro_id { get; set; }

        public virtual UserDb? User { get; set; }
        public virtual HoTroDb? Hotro { get; set; }
    }
}
