namespace Hue_Festival_Online_Ticket.Model.Response
{
    public class HistoryCheckInTicketNVResponseDTO
    {
        public int ID_ve { get; set; }
        public string? Type { get; set; }
        public string? Nguoidat_name { get; set; }
        public string? Chuongtrinh_name { get; set; }
        public string? Price { get; set; }
        public string? Time { get; set; }
        public DateTime? Program_start_date { get; set; }
        public string? Diadiem { get; set; }
        public DateTime? Date_soatve { get; set; }
        public string? Status { get; set; }
    }
}
