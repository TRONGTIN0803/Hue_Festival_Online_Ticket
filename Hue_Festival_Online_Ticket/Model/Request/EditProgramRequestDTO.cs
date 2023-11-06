namespace Hue_Festival_Online_Ticket.Model.Request
{
    public class EditProgramRequestDTO
    {
        public int ID_chuongtrinh { get; set; }
        public string? Chuongtrinh_name { get; set; }
        public string? Chuongtrinh_content { get; set; }
        public int? Type_inoff { get; set; }
        public int? Price { get; set; }
        public int? Type_program { get; set; }
        public int? Diadiem_id { get; set; }
        public string? Time { get; set; }
        public string? Fdate { get; set; }
        public string? Tdate { get; set; }
        public int? Nhom_id { get; set; }
        public int? Doan_id { get; set; }
    }
}
