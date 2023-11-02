using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Chuongtrinh")]
    public class ChuongTrinhDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_chuongtrinh { get; set; }
        public string? Chuongtrinh_name { get; set; }
        public string? Chuongtrinh_content { get; set; }
        public int? Type_inoff { get; set; }
        public int? Price { get; set; }
        public int? Type_program { get; set; }
        public int? Diadiem_id { get; set; }
        public string? Time { get; set; }
        public DateTime? Fdate { get; set; }
        public DateTime? Tdate { get; set; }
        public int? Nhom_id { get; set; }
        public int? Doan_id { get; set; }

        public virtual List<DiaDiemSoatVeDb>? list_DiaDiemSoatVe { get; set; }
        public virtual List<ChuongTrinhImageDb>? list_Image { get; set; }
        public virtual List<ChuongTrinhYeuThichDb>? list_ChuongTrinhYeuThichDb { get; set; }
        public virtual List<VeDb>? list_Ve { get; set; }
        public virtual DiaDiemDb? Diadiem { get; set; }
        public virtual NhomDb? Nhom { get; set; }
        public virtual DoanDb? Doan { get; set; }
    }
}
