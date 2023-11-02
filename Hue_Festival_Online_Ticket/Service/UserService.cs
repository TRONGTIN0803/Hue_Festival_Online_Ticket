using AutoMapper;
using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.Data;
using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;
using Hue_Festival_Online_Ticket.Model.Response;
using Microsoft.EntityFrameworkCore;

namespace Hue_Festival_Online_Ticket.Service
{
    public class UserService : IUserService
    {
        private readonly Hue_Festival_Context _context;
        private readonly IMapper _mapper;
        public UserService(Hue_Festival_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /*
        * role = 1 -> admin ; 2 -> customer
        */


        public async Task<KqJson> bookTicketHistory(int user_id)
        {
            KqJson kq = new KqJson();
            try
            {
                if (user_id > 0)
                {
                    var result = await (from v in _context.veDbs
                                        join ct in _context.chuongTrinhDbs
                                        on v.Chuongtrinh_id equals ct.ID_chuongtrinh
                                        where v.User_id == user_id && v.Status== null
                                        orderby v.ID_ve descending
                                        select new HistoryBookingTicketResponseDTO
                                        {
                                            Ve_id = v.ID_ve,
                                            Chuongtrinh_name=ct.Chuongtrinh_name,
                                            Price=ct.Price+"",
                                            Type = v.Type+"",
                                            Time = ct.Time,
                                            Date=ct.Fdate
                                        }).ToListAsync();
                    if(result.Count > 0)
                    {
                        foreach(var ve in result)
                        {
                            if (ve.Price == "0")
                            {
                                ve.Price = "Mien phi";
                            }
                            if (ve.Type == "1")
                            {
                                ve.Type = "VIP";
                            }
                            else
                            {
                                ve.Type = "Thuong";
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
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }
        public async Task<KqJson> getAboutDetail(int about_id)
        {
            KqJson kq = new KqJson();
            try
            {
                if (about_id > 0)
                {
                    var result = await (from ht in _context.hoTroDbs
                                        where ht.ID_hotro == about_id
                                        select new
                                        {
                                            title = ht.Hotro_title,
                                            content = ht.Hotro_content
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
                    throw new Exception("Bad Request");
                }
            }
            catch (Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> getAboutList()
        {
            KqJson kq = new KqJson();
            try
            {
                var result = await (from ht in _context.hoTroDbs
                                    select new
                                    {
                                        id = ht.ID_hotro,
                                        title = ht.Hotro_title
                                    }).ToListAsync();
                if (result.Count > 0)
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
            catch (Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> get_wish_diadiem_list(int userId)
        {
            KqJson kq = new KqJson();
            try
            {
                if (userId > 0)
                {
                    var result = await (from u in _context.userDbs
                                        join w in _context.diaDiemYeuThichDbs
                                        on u.ID_user equals w.User_id
                                        join dd in _context.diaDiemDbs
                                        on w.Diadiem_id equals dd.ID_diadiem
                                        where w.User_id == userId && w.IsWish==true
                                        select new
                                        {
                                            id = dd.ID_diadiem,
                                            title = dd.Diadiem_title,
                                            pathImage = dd.PathImage
                                        }).ToListAsync();
                    if (result.Count > 0)
                    {

                        kq.status = true;
                        kq.msg = "Thanh cong";
                        kq.data = result;
                        return kq;
                    }
                    else
                    {
                        throw new Exception("Not found");
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

        public async Task<KqJson> get_wish_program_list(int userId)
        {
            KqJson kq = new KqJson();
            try
            {
                if (userId > 0)
                {
                    var result = await (from u in _context.userDbs
                                        join w in _context.chuongTrinhYeuThichDbs
                                        on u.ID_user equals w.User_id
                                        join ct in _context.chuongTrinhDbs
                                        on w.Chuongtrinh_id equals ct.ID_chuongtrinh
                                        where w.User_id == userId && w.IsWish==true
                                        select new ChuongTrinhDb
                                        {
                                            ID_chuongtrinh = ct.ID_chuongtrinh,
                                            Chuongtrinh_name = ct.Chuongtrinh_name,
                                            list_Image = ct.list_Image
                                        }).ToListAsync();
                    if (result.Count > 0)
                    {
                        foreach (var ct in result)
                        {
                            List<ChuongTrinhImageDb> list_img = new List<ChuongTrinhImageDb>();
                            foreach (var img in ct.list_Image)
                            {
                                ChuongTrinhImageDb image = new ChuongTrinhImageDb();
                                image.ID_image = img.ID_image;
                                image.Image_path = img.Image_path;
                                list_img.Add(image);
                            }
                            ct.list_Image = list_img;
                        }
                        List<ChuongtrinhResponeDTO> res = new List<ChuongtrinhResponeDTO>();
                        res = _mapper.Map<List<ChuongtrinhResponeDTO>>(result);
                        kq.status = true;
                        kq.msg = "Thanh cong";
                        kq.data = res;
                        return kq;
                    }
                    else
                    {
                        throw new Exception("Not found");
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

        public async Task<KqJson> get_wish_tintuc_list(int userId)
        {
            KqJson kq = new KqJson();
            try
            {
                if (userId > 0)
                {
                    var result = await (from u in _context.userDbs
                                        join w in _context.tinTucYeuThichDbs
                                        on u.ID_user equals w.User_id
                                        join tt in _context.tinTucDbs
                                        on w.Tintuc_id equals tt.ID_tintuc
                                        where w.User_id == userId && w.IsWish == true
                                        select new TinTucDb
                                        {
                                            ID_tintuc = tt.ID_tintuc,
                                            Tintuc_title = tt.Tintuc_title,
                                            list_Image = tt.list_Image
                                        }).ToListAsync();
                    if (result.Count > 0)
                    {
                        foreach (var ct in result)
                        {
                            List<TinTucImageDb> list_img = new List<TinTucImageDb>();
                            foreach (var img in ct.list_Image)
                            {
                                TinTucImageDb image = new TinTucImageDb();
                                image.ID_image = img.ID_image;
                                image.Image_path = img.Image_path;
                                list_img.Add(image);
                            }
                            ct.list_Image = list_img;
                        }
                        List<TintucResponeDTO> res = new List<TintucResponeDTO>();
                        res = _mapper.Map<List<TintucResponeDTO>>(result);
                        kq.status = true;
                        kq.msg = "Thanh cong";
                        kq.data = res;
                        return kq;
                    }
                    else
                    {
                        throw new Exception("Not found");
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

        public async Task<KqJson> historyCheckInTicketlist(int user_id)
        {
            KqJson kq = new KqJson();
            try
            {
                if (user_id > 0)
                {
                    var result = await(from ve in _context.veDbs
                                       join ct in _context.chuongTrinhDbs
                                       on ve.Chuongtrinh_id equals ct.ID_chuongtrinh
                                       join dd in _context.diaDiemDbs
                                       on ct.Diadiem_id equals dd.ID_diadiem
                                       where ve.User_id == user_id
                                       orderby ve.Date_soatve descending
                                       select new HistoryCheckInTicketUserResponseDTO
                                       {
                                           ID_ve = ve.ID_ve,
                                           Type = ve.Type + "",
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
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> loginUser(DangNhapRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model.Sdt != "" && model.Pasword != "")
                {
                    var result = await (from u in _context.userDbs
                                        where u.User_phone.Equals(model.Sdt) && u.User_password.Equals(model.Pasword)
                                        select new
                                        {
                                            id = u.ID_user,
                                            name = u.User_name,
                                            sdt = u.User_phone
                                        }).SingleOrDefaultAsync();
                    if (result != null)
                    {
                        kq.status = true;
                        kq.msg = "Login Successfully";
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

        public async Task<KqJson> register(DangkyRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model.Sdt != "" && model.Password != "" && model.Name != "")
                {
                    var check_sdt = await _context.userDbs.SingleOrDefaultAsync(p => p.User_phone == model.Sdt);
                    if (check_sdt != null)
                    {
                        throw new Exception("Sdt da duoc su dung");
                    }
                    UserDb add_model = new UserDb();
                    add_model.User_phone = model.Sdt;
                    add_model.User_password = model.Password;
                    add_model.User_name = model.Name;
                    add_model.User_role = 2;
                    await _context.userDbs.AddAsync(add_model);
                    int row = await _context.SaveChangesAsync();
                    if (row > 0)
                    {
                        kq.status = true;
                        kq.msg = "Dang ky thanh cong";
                        return kq;
                    }
                    else
                    {
                        throw new Exception("Dang ky that bai");
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
