using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Diadiem")]
    public class DiaDiemDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_diadiem { get; set; }
        public string? Diadiem_title { get; set; }
        public string? Diadiem_summary { get; set; }
        public string? Diadiem_content { get; set; }
        public string? PathImage { get; set; }
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }
        public int? Submenu_id { get; set; }
        public string? Number_phone { get; set; }
        public string? Diachi { get; set; }

        public virtual List<ChuongTrinhDb>? list_Chuongtrinh { get; set; }
        public virtual SubMenuDb? Submenu { get; set; }
    }
}
