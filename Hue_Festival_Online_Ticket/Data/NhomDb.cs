using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Nhom")]
    public class NhomDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_nhom { get; set; }
        public string? Nhom_name { get; set; }

        public virtual List<LichDienDb>? list_Lichdien { get; set; }
    }
}
