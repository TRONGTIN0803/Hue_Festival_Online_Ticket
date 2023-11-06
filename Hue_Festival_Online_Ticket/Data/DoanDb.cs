using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Doan")]
    public class DoanDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_doan { get; set; }
        public string? Doan_name { get; set; }

        public virtual List<ChuongTrinhDb>? list_Chuongtrinh { get; set; }
    }
}
