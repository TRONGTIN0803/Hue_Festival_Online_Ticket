using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("DiaDiemYeuThichDb")]
    public class DiaDiemYeuThichDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_diadiem_yeuthich { get; set; }
        public bool? IsWish { get; set; }
        public int? User_id { get; set; }
        public int? Diadiem_id { get; set; }

        public virtual UserDb? User { get; set; }
        public virtual DiaDiemDb? Diadiem { get; set; }
    }

}
