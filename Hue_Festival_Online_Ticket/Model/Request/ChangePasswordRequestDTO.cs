namespace Hue_Festival_Online_Ticket.Model.Request
{
    public class ChangePasswordRequestDTO
    {
        public int User_id { get; set; }
        public string Old_password { get; set; }
        public string New_password { get; set; }
        public string Re_new_password { get; set; }
    }
}
