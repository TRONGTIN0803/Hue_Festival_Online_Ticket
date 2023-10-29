using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("ChuongtrinhYeuthich")]
    public class ChuongTrinhYeuThichDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_chuongtrinh_yeuthich { get; set; }
        public bool? IsWish { get; set; }
        public int? User_id { get; set; }
        public int? Chuongtrinh_id { get; set; }

        public virtual UserDb? User { get; set; }
        public virtual ChuongTrinhDb? Chuongtrinh { get; set; }
    }
}
