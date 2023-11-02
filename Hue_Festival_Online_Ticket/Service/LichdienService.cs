using AutoMapper;
using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.Data;
using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Response;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Xml;

namespace Hue_Festival_Online_Ticket.Service
{
    public class LichdienService:ILichdienService
    {
        private readonly Hue_Festival_Context _context;
        private readonly IMapper _mapper;
        public LichdienService(Hue_Festival_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<KqJson> getCarlenderList()
        {
            KqJson kq = new KqJson();
            try
            {
                List<CalenderResponeDTO> result = new List<CalenderResponeDTO>();
                for(var i = 0; i <= 10; i++)
                {
                    CalenderResponeDTO cal = new CalenderResponeDTO();
                    var datenow=DateTime.Now.Date.AddDays(i);
                    var thu = datenow.DayOfWeek;
                    //var countprogram = await (from ld in _context.chuongTrinhDbs
                    //                          where ld.Fdate <= datenow && ld.Tdate >= datenow
                    //                          group ld by ld.ID_chuongtrinh into id
                    //                          select id.Count()).SingleOrDefaultAsync();
                    var program = await (from ld in _context.chuongTrinhDbs
                                              where ld.Fdate <= datenow && ld.Tdate >= datenow
                                              select ld.ID_chuongtrinh).ToListAsync();
                    var countprogram = program.Count();
                    cal.date = datenow;
                    cal.dayofweek = "" + thu;
                    cal.mumberprogram = "Co " + countprogram + " chuong trinh";
                    result.Add(cal);
                }
                kq.status = true;
                kq.msg = "thanh cong";
                kq.data = result;
                return kq;
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> getCarlenderProgramList(string date)
        {
            KqJson kq = new KqJson();
            try
            {
                DateTime ngay;
                if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay))
                {
                    var result = await (from ct in _context.chuongTrinhDbs
                                        join dd in _context.diaDiemDbs
                                        on ct.Diadiem_id equals dd.ID_diadiem
                                        where ct.Fdate <= ngay && ct.Tdate >= ngay
                                        select new
                                        {
                                            ID_Chuongtrinh = ct.ID_chuongtrinh,
                                            Chuongtrinh_name = ct.Chuongtrinh_name,
                                            Type_inoff = ct.Type_inoff,
                                            Time = ct.Time,
                                            Date = ct.Fdate,
                                            Diadiem = dd.Diadiem_title
                                        }).ToListAsync();
                    if(result.Count > 0)
                    {
                        kq.status = true;
                        kq.msg = "Thanh cong";
                        kq.data = result;
                        return kq;
                    }
                    else
                    {
                        throw new Exception("Not Found");
                    }
                    
                }
                else
                {
                    throw new Exception("Ngày không hợp lệ. Ngày có dang'yyyy-mm-dd'");
                }
            }
            catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }
    }
}
