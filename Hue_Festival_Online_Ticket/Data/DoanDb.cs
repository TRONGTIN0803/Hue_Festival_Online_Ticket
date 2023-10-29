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
        public string? Nhom_doan { get; set; }

        public virtual List<LichDienDb>? list_Lichdien { get; set; }
    }
}
