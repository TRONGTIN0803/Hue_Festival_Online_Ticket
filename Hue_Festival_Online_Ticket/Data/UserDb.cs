using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hue_Festival_Online_Ticket.Data
{
    [Table("User")]
    public class UserDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_user { get; set; }
        public string? User_name { get; set; }
        public string? User_password { get; set; }
        public string? User_phone { get; set; }
        public int? User_role { get; set; }

        public virtual List<HoTroUserDb>? list_HotroUser { get; set; }
        public virtual List<TinTucYeuThichDb>? list_TintucYeuthich { get; set; }
        public virtual List<ChuongTrinhYeuThichDb>? list_ChuongtrinhYeuthich { get; set; }
        public virtual List<VeDb>? list_Ve { get; set; }
        public virtual List<DiaDiemYeuThichDb>? list_Diadiemyeuthich { get; set; }
    }
}
