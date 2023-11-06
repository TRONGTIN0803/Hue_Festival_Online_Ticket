namespace Hue_Festival_Online_Ticket.Model.Request
{
    public class DiadiemRequestDTO
    {
        public int? ID_diadiem { get; set; }
        public string? Diadiem_title { get; set; }
        public string? Diadiem_summary { get; set; }
        public string? Diadiem_content { get; set; }
        public string? PathImage { get; set; }
        public double? Longtitude { get; set; }
        public double? Latitude { get; set; }
        public int? Submenu_id { get; set; }
        public string? Number_phone { get; set; }
        public string? Diachi { get; set; }
    }
}
