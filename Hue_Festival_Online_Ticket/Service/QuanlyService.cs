using AutoMapper;
using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;
using Hue_Festival_Online_Ticket.Model.Response;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;

namespace Hue_Festival_Online_Ticket.Service
{
    public class QuanlyService : IQuanlyService
    {
        private readonly Hue_Festival_Context _context;
        private readonly IMapper _mapper;
        public QuanlyService(Hue_Festival_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /*
        * role = 1 -> admin ; 2 -> customer
        */

        public async Task<KqJson> checkInfoTicket(int ve_id)
        {
            KqJson kq = new KqJson();
            try
            {
                if (ve_id > 0)
                {
                    var result = await (from v in _context.veDbs
                                        join ct in _context.chuongTrinhDbs
                                        on v.Chuongtrinh_id equals ct.ID_chuongtrinh
                                        join u in _context.userDbs
                                        on v.User_id equals u.ID_user
                                        join dd in _context.diaDiemDbs
                                        on ct.Diadiem_id equals dd.ID_diadiem
                                        where v.ID_ve == ve_id
                                        select new
                                        {
                                            id = v.ID_ve,
                                            user_name = u.User_name,
                                            type = v.Type,
                                            chuongtrinh_name = ct.Chuongtrinh_name,
                                            price = ct.Price,
                                            time = ct.Time,
                                            date = ct.Fdate,
                                            diadiem = dd.Diadiem_title
                                        }).SingleOrDefaultAsync();
                    if (result != null)
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
                    throw new Exception("Bad request");
                }
            }
            catch (Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> checkInTicket(CheckInTicketRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model.Nguoisoat_id > 0 && model.Ve_id > 0 && model.IsActive != null)
                {
                    var ve = await _context.veDbs.SingleOrDefaultAsync(p => p.ID_ve == model.Ve_id);
                    if (ve != null)
                    {
                        ve.NV_soatve = model.Nguoisoat_id;
                        ve.Date_soatve = DateTime.Now;
                        ve.Status = model.IsActive;

                        int row = await _context.SaveChangesAsync();
                        if (row > 0)
                        {
                            kq.status = true;
                            kq.msg = "Check In Successfully";
                            return kq;
                        }
                        else
                        {
                            throw new Exception("Check In Failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Not Found");
                    }
                }
                else
                {
                    throw new Exception("Bad request");
                }
            }
            catch (Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> getThongkeTicket(string date, int type, int chuongtrinh_id)
        {
            KqJson kq = new KqJson();
            try
            {
                if (date != "")
                {
                    DateTime ngay;
                    if (DateTime.TryParseExact(date, "yyyy-MM", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay))
                    {
                        List<ThongkeTicketResponseDTO> CountTicket = new List<ThongkeTicketResponseDTO>();
                        if (type == 0 && chuongtrinh_id == 0)
                        {
                            CountTicket = await (from ve in _context.veDbs
                                                 where ve.Date_soatve.ToString().StartsWith(date)
                                                 group ve by ve.Chuongtrinh_id into idve
                                                 select new ThongkeTicketResponseDTO
                                                 {
                                                     Chuongtrinh_id = idve.Key,
                                                     Quantity_ticket = idve.Count()
                                                 }).ToListAsync();

                        }
                        else if (type > 0 && chuongtrinh_id == 0)
                        {
                            if (type == 1 || type == 2)
                            {
                                CountTicket = await (from ve in _context.veDbs
                                                     where ve.Date_soatve.ToString().StartsWith(date) &&
                                                     ve.Type == type
                                                     group ve by ve.Chuongtrinh_id into idve
                                                     select new ThongkeTicketResponseDTO
                                                     {
                                                         Chuongtrinh_id = idve.Key,
                                                         Quantity_ticket = idve.Count()
                                                     }).ToListAsync();
                            }
                            else
                            {
                                throw new Exception("Loại vé không hợp lệ");
                            }
                        }
                        else if (type == 0 && chuongtrinh_id > 0)
                        {
                            if (chuongtrinh_id > 0)
                            {
                                CountTicket = await (from ve in _context.veDbs
                                                     where ve.Date_soatve.ToString().StartsWith(date) &&
                                                     ve.Chuongtrinh_id==chuongtrinh_id
                                                     group ve by ve.Chuongtrinh_id into idve
                                                     select new ThongkeTicketResponseDTO
                                                     {
                                                         Chuongtrinh_id = idve.Key,
                                                         Quantity_ticket = idve.Count()
                                                     }).ToListAsync();
                            }
                            else
                            {
                                throw new Exception("ID chương trình không hợp lệ");
                            }
                        }
                        else if(type>0 && chuongtrinh_id > 0)
                        {
                            if (type == 1 || type == 2)
                            {
                                CountTicket = await (from ve in _context.veDbs
                                                     where ve.Date_soatve.ToString().StartsWith(date) &&
                                                     ve.Type == type && ve.Chuongtrinh_id==chuongtrinh_id
                                                     group ve by ve.Chuongtrinh_id into idve
                                                     select new ThongkeTicketResponseDTO
                                                     {
                                                         Chuongtrinh_id = idve.Key,
                                                         Quantity_ticket = idve.Count()
                                                     }).ToListAsync();
                            }
                            else
                            {
                                throw new Exception("Loại vé không hợp lệ");
                            }
                        }
                        else if(type<0 && chuongtrinh_id < 0)
                        {
                            throw new Exception("Loại vé và ID chương trình không hợp lệ");
                        }
                        else
                        {
                            throw new Exception("Loại vé hoặc ID chương trình không hợp lệ");
                        }

                        if (CountTicket.Count > 0)
                        {
                            foreach (var ve in CountTicket)
                            {
                                var ct_name = await (from ct in _context.chuongTrinhDbs
                                                     where ct.ID_chuongtrinh == ve.Chuongtrinh_id
                                                     select ct.Chuongtrinh_name).SingleOrDefaultAsync();
                                ve.Chuongtrinh_name = ct_name;
                            }
                            kq.status = true;
                            kq.msg = "Thanh cong";
                            kq.data = CountTicket;
                            return kq;
                        }
                        else
                        {
                            throw new Exception("Not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Thời gian thống kê không đúng định dạng, thời gian có dạng 'yyyy-MM'");
                    }
                }
                else
                {
                    throw new Exception("Thời gian thống kê không thể để trống");
                }
            }
            catch (Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> historyCheckInTicketList(int nguoisoat_id)
        {
            KqJson kq = new KqJson();
            try
            {
                if (nguoisoat_id > 0)
                {
                    var result = await (from ve in _context.veDbs
                                        join u in _context.userDbs
                                        on ve.User_id equals u.ID_user
                                        join ct in _context.chuongTrinhDbs
                                        on ve.Chuongtrinh_id equals ct.ID_chuongtrinh
                                        join dd in _context.diaDiemDbs
                                        on ct.Diadiem_id equals dd.ID_diadiem
                                        where ve.NV_soatve == nguoisoat_id
                                        orderby ve.Date_soatve descending
                                        select new HistoryCheckInTicketNVResponseDTO
                                        {
                                            ID_ve = ve.ID_ve,
                                            Type = ve.Type + "",
                                            Nguoidat_name = u.User_name,
                                            Chuongtrinh_name = ct.Chuongtrinh_name,
                                            Price = ct.Price + "",
                                            Time = ct.Time,
                                            Program_start_date = ct.Fdate,
                                            Diadiem = dd.Diadiem_title,
                                            Date_soatve = ve.Date_soatve,
                                            Status = ve.Status + ""
                                        }).ToListAsync();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            if (item.Price == "0")
                            {
                                item.Price = "Mien phi";
                            }
                            if (item.Type == "1")
                            {
                                item.Type = "VIP";
                            }
                            else
                            {
                                item.Type = "Thuong";
                            }
                            if (item.Status == "True")
                            {
                                item.Status = "Ve hop le";
                            }
                            else
                            {
                                item.Status = "Ve khong hop le";
                            }
                        }
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
                    throw new Exception("Bad request");
                }
            }
            catch (Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> loginAdmin(DangNhapRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model.Sdt != "" && model.Pasword != "")
                {
                    var result = await (from u in _context.userDbs
                                        where u.User_phone == model.Sdt &&
                                        u.User_password == model.Pasword && u.User_role == 1
                                        select new
                                        {
                                            id = u.ID_user,
                                            name = u.User_name,
                                            sdt = u.User_phone
                                        }).SingleOrDefaultAsync();
                    if (result != null)
                    {
                        kq.status = true;
                        kq.msg = "Login sucessfully";
                        kq.data = result;
                        return kq;
                    }
                    else
                    {
                        throw new Exception("Login Failed");
                    }
                }
                else
                {
                    throw new Exception("Bad Request");
                }
            }
            catch (Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }
    }
}
