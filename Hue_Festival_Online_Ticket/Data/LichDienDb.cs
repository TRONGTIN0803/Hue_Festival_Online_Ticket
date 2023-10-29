using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Lichdien")]
    public class LichDienDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_lichdien { get; set; }
        public string? Time { get; set; }
        public DateTime? Fdate { get; set; }
        public DateTime? Tdate { get; set; }
        public int? Chuongtrinh_id { get; set; }
        public int? Nhom_id { get; set; }
        public int? Doan_id { get; set; }

        public virtual NhomDb? Nhom { get; set; }
        public virtual DoanDb? Doan { get; set; }
        public virtual ChuongTrinhDb? Chuongtrinh { get; set; }
    }
}
