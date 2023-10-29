using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("TintucImage")]
    public class TinTucImageDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_image { get; set; }
        public string? Image_path { get; set; }
        public int? Tintuc_id { get; set; }

        public virtual TinTucDb? Tintuc { get; set; }
    }
}
