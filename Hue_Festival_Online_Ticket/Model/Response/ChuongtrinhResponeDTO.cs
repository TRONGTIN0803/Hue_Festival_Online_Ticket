using Hue_Festival_Online_Ticket.Data;

namespace Hue_Festival_Online_Ticket.Model.Response
{
    public class ChuongtrinhResponeDTO
    {
        public int ID_chuongtrinh { get; set; }
        public string? Chuongtrinh_name { get; set; }
        public string? Chuongtrinh_content { get; set; }
        public int? Type_inoff { get; set; }
        public int? Price { get; set; }
        public int? Type_program { get; set; }
        public List<DetailChuongtrinhResponeDTO>? detail_list { get; set; }
        public virtual List<ChuongtrinhImageResponeDTO>? list_Image { get; set; }

    }
}
