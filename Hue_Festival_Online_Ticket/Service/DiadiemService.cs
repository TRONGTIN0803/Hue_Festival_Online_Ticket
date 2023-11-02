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
    public class DiadiemService:IDiadiemService
    {
        private readonly Hue_Festival_Context _context;
        private readonly IMapper _mapper;
        public DiadiemService(Hue_Festival_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /*
         * type = 1 -> VIP ; 2 -> thuong
         */

        public async Task<KqJson> addVe(AddVeRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if(model.User_id>0 && model.Chuongtrinh_id > 0 && model.Type>0)
                {
                    if(model.Type==1 || model.Type == 2)
                    {
                        VeDb ve = new VeDb();
                        ve.User_id = model.User_id;
                        ve.Chuongtrinh_id = model.Chuongtrinh_id;
                        ve.Type = model.Type;

                        await _context.veDbs.AddAsync(ve);
                        int row = await _context.SaveChangesAsync();
                        if (row > 0)
                        {
                            kq.status = true;
                            kq.msg = "Add sucessfully";
                            return kq;
                        }
                        else
                        {
                            throw new Exception("Add Failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Loai ve khong hop le");
                    }
                }
                else
                {
                    throw new Exception("Bad Request");
                }
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> changeWishDiadiem(YeuthichRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model.User_id > 0 && model.Entity_wish_id > 0)
                {
                    int row = 0;
                    var check_wish = await (from w in _context.diaDiemYeuThichDbs
                                            where w.User_id == model.User_id && w.Diadiem_id == model.Entity_wish_id
                                            select w).SingleOrDefaultAsync();
                    if (check_wish == null)
                    {
                        DiaDiemYeuThichDb model_add = new DiaDiemYeuThichDb();
                        model_add.User_id = model.User_id;
                        model_add.Diadiem_id = model.Entity_wish_id;
                        model_add.IsWish = true;

                        await _context.diaDiemYeuThichDbs.AddAsync(model_add);
                        row = await _context.SaveChangesAsync();
                        kq.msg = "Da them yeu thich";
                    }
                    else
                    {
                        if (check_wish.IsWish == true)
                        {
                            check_wish.IsWish = false;
                            row = await _context.SaveChangesAsync();
                            kq.msg = "Da huy yeu thich";
                        }
                        else
                        {
                            check_wish.IsWish = true;
                            row = await _context.SaveChangesAsync();
                            kq.msg = "Da them yeu thich";
                        }
                    }
                    if (row > 0)
                    {
                        kq.status = true;
                        return kq;
                    }
                    else
                    {
                        throw new Exception("That bai");
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

        public async Task<KqJson> getMenuList()
        {
            KqJson kq = new KqJson();
            try
            {
                var list_menu = await _context.menuDbs.ToListAsync();
                if (list_menu.Count > 0)
                {
                    foreach (var menu in list_menu)
                    {
                        var col = _context.Entry(menu);
                        await col.Collection(p => p.list_Submenu).LoadAsync();
                        List<SubMenuDb> list_submenu = new List<SubMenuDb>();
                        foreach(var submenu in menu.list_Submenu)
                        {
                            SubMenuDb subDb = new SubMenuDb();
                            subDb.ID_submenu=submenu.ID_submenu;
                            subDb.Submenu_title=submenu.Submenu_title;
                            subDb.PathIcon=submenu.PathIcon;
                            list_submenu.Add(subDb);
                        }
                        menu.list_Submenu = list_submenu;
                    }
                    List<MenuResponeDTO> result = new List<MenuResponeDTO>();
                    result=_mapper.Map<List<MenuResponeDTO>>(list_menu);
                    kq.status = true;
                    kq.msg = "Thanh cong";
                    kq.data = result;
                    return kq;
                }
                else
                {
                    throw new Exception("Not Found");
                }
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> getPriceTicketProgram()
        {
            KqJson kq = new KqJson();
            try
            {
                var result = await (from ct in _context.chuongTrinhDbs
                                    where ct.Type_inoff==2
                                    select new
                                    {
                                        Id=ct.ID_chuongtrinh,
                                        Name=ct.Chuongtrinh_name,
                                        Price=ct.Price
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
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> getServiceDetail(int id_diadiem)
        {
            KqJson kq = new KqJson();
            try
            {
                if (id_diadiem > 0)
                {
                    var result = await _context.diaDiemDbs.SingleOrDefaultAsync(p=>p.ID_diadiem==id_diadiem);
                    if (result != null)
                    {
                        DiadiemResponeDTO dd = new DiadiemResponeDTO();
                        dd = _mapper.Map<DiadiemResponeDTO>(result);
                        kq.status = true;
                        kq.msg = "Thành công";
                        kq.data = dd;
                        return kq;
                    }
                    else
                    {
                        throw new Exception("Not found");
                    }
                }
                else
                {
                    throw new Exception("ID không phù hợp");
                }
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> getServiceList(int id_submenu)
        {
            KqJson kq = new KqJson();
            try
            {
                if (id_submenu > 0)
                {
                    var list_diadiem = await _context.diaDiemDbs.Where(p => p.Submenu_id == id_submenu).ToListAsync();
                    if (list_diadiem.Count > 0)
                    {
                        List<DiadiemResponeDTO> result = new List<DiadiemResponeDTO>();
                        result = _mapper.Map<List<DiadiemResponeDTO>>(list_diadiem);
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
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> getTicketLocation()
        {
            KqJson kq = new KqJson();
            try
            {
                var result = await _context.diaDiemDbs.Where(p => p.Submenu_id == 7).ToListAsync();
                if(result.Count > 0)
                {
                    List<DiembanveResponeDTO> list_ticket_location = new List<DiembanveResponeDTO>();
                    list_ticket_location=_mapper.Map<List<DiembanveResponeDTO>>(result);
                    kq.status = true;
                    kq.msg = "Thanh cong";
                    kq.data=list_ticket_location;
                    return kq;
                }
                else
                {
                    throw new Exception("Not Found");
                }
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }
    }
}
