using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("DiadiemSoatve")]
    public class DiaDiemSoatVeDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_diadiem_soatve { get; set; }
        public DateTime? Date { get; set; }
        public string? Start_time { get; set; }
        public string? End_time { get; set; }
        public int? Chuongtrinh_id { get; set; }

        public virtual ChuongTrinhDb? Chuongtrinh { get; set; }
    }
}
