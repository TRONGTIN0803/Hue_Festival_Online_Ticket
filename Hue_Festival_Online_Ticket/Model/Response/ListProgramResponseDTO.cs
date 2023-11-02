namespace Hue_Festival_Online_Ticket.Model.Response
{
    public class ListProgramResponseDTO
    {
        public int ID_chuongtrinh { get; set; }
        public string? Chuongtrinh_name { get; set; }
        public string? Chuongtrinh_content { get; set; }
        public int? Type_inoff { get; set; }
        public int? Price { get; set; }
        public DateTime? Fdate { get; set; }
        public DateTime? Tdate { get; set; }

        public virtual List<ChuongtrinhImageResponeDTO>? list_Image { get; set; }
    }
}
