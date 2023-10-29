using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("ChuongtrinhImage")]
    public class ChuongTrinhImageDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_image { get; set; }
        public string? Image_path { get; set; }
        public int? Chuongtrinh_id { get; set; }

        public virtual ChuongTrinhDb? Chuongtrinh { get; set; }
    }
}
