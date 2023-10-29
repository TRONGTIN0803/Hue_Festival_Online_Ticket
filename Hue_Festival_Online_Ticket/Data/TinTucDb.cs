using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("Tintuc")]
    public class TinTucDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_tintuc { get; set; }
        public string? Tintuc_title { get; set; }
        public string? Tintuc_content { get; set; }
        public DateTime? Tintuc_time { get; set; }

        public virtual List<TinTucImageDb>? list_Image { get; set; }
        public virtual List<TinTucYeuThichDb>? list_TintucYeuthich { get; set; }
    }
}
