using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Ve")]
    public class VeDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_ve { get; set; }
        public int? Type { get; set; }
        public int? User_id { get; set; }
        public int? Chuongtrinh_id { get; set; }
        public int? NV_soatve { get; set; }
        public DateTime? Date_soatve { get; set; }
        public bool? Status { get; set; }

        public virtual UserDb? User { get; set; }
        public virtual ChuongTrinhDb? Chuongtrinh { get; set; }
    }
}
