using AutoMapper;
using Hue_Festival_Online_Ticket.Data;
using Hue_Festival_Online_Ticket.Model.Response;


namespace Hue_Festival_Online_Ticket.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ChuongTrinhDb, ChuongtrinhResponeDTO>();
            CreateMap<ChuongTrinhImageDb, ChuongtrinhImageResponeDTO>();
            CreateMap<MenuDb, MenuResponeDTO>();
            CreateMap<SubMenuDb, SubMenuResponeDTO>();
            CreateMap<DiaDiemDb, DiadiemResponeDTO>();
        }

    }
}

