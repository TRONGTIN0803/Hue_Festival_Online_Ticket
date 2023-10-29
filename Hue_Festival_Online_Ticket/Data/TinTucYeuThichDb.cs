using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("TintucYeuthich")]
    public class TinTucYeuThichDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_wish_tintuc { get; set; }
        public bool? IsWish { get; set; }
        public int? User_id { get; set; }
        public int? Tintuc_id { get; set; }

        public virtual UserDb? User { get; set; }
        public virtual TinTucDb? TinTuc { get; set; }
    }
}
