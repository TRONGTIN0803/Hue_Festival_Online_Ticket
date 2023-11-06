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
        public async Task<KqJson> addDiadiem(DiadiemRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if (model.Diadiem_title != null)
                    {
                        DiaDiemDb diaDiem = new DiaDiemDb();
                        diaDiem.Diadiem_title = model.Diadiem_title;
                        diaDiem.Diadiem_content = model.Diadiem_content!=null?model.Diadiem_content:null;
                        diaDiem.Diadiem_summary = model.Diadiem_summary!=null?model.Diadiem_summary:null;
                        diaDiem.PathImage = model.PathImage!=null?model.PathImage:null;
                        diaDiem.Longtitude = model.Longtitude!=null?model.Longtitude:null;
                        diaDiem.Latitude = model.Latitude!=null?model.Latitude:null;
                        diaDiem.Submenu_id = model.Submenu_id!=null?model.Submenu_id:null;
                        diaDiem.Number_phone = model.Number_phone!=null?model.Number_phone:null;
                        diaDiem.Diachi = model.Diachi!=null?model.Diachi:null;

                        await _context.diaDiemDbs.AddAsync(diaDiem);
                        int row = await _context.SaveChangesAsync();
                        if (row > 0)
                        {
                            kq.status = true;
                            kq.msg = "Add Successfully";
                            return kq;
                        }
                        else
                        {
                            throw new Exception("Add Failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Dữ liệu không được để trống");
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
        public async Task<KqJson> addMenu(MenuRequestDTO model)
        {
            KqJson kq=new KqJson();
            try
            {
                if (model != null)
                {
                    if(model.Menu_title!=null && model.PathIcon != null)
                    {
                        MenuDb menu = new MenuDb();
                        menu.Menu_title = model.Menu_title;
                        menu.PathIcon = model.PathIcon;

                        await _context.menuDbs.AddAsync(menu);
                        int row = await _context.SaveChangesAsync();
                        if (row > 0)
                        {
                            kq.status = true;
                            kq.msg = "Add Successfully";
                            return kq;
                        }
                        else
                        {
                            throw new Exception("Add Failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Dữ liệu không được để trống");
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

        public async Task<KqJson> addSubMenu(SubMenuRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if(model.Submenu_title!=null && model.PathIcon != null)
                    {
                        SubMenuDb submenu = new SubMenuDb();
                        submenu.Submenu_title = model.Submenu_title;
                        submenu.PathIcon = model.PathIcon;
                        submenu.Menu_id= model.Menu_id!=null?model.Menu_id:null;

                        await _context.subMenuDbs.AddAsync(submenu);
                        int row = await _context.SaveChangesAsync();
                        if (row > 0)
                        {
                            kq.status = true;
                            kq.msg = "Add Successfully";
                            return kq;
                        }
                        else
                        {
                            throw new Exception("Add Failed");
                        }
                    }
                    else
                    {
                        throw new Exception("Dữ liệu không được để trống");
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

        public async Task<KqJson> deleteDiadiem(DeleteEntityRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if (model.Id > 0)
                    {
                        var result = await _context.diaDiemDbs.SingleOrDefaultAsync(p => p.ID_diadiem == model.Id);
                        if (result != null)
                        {
                            _context.diaDiemDbs.Remove(result);
                            int row = await _context.SaveChangesAsync();
                            if (row > 0)
                            {
                                kq.status = true;
                                kq.msg = "Delete Successfully";
                                return kq;
                            }
                            else
                            {
                                throw new Exception("Delete Failed");
                            }
                        }
                        else
                        {
                            throw new Exception("Not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Find Error");
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

        public async Task<KqJson> deleteMenu(DeleteEntityRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if (model.Id > 0)
                    {
                        var result = await _context.menuDbs.SingleOrDefaultAsync(p=>p.ID_menu==model.Id);
                        if (result != null)
                        {
                            _context.menuDbs.Remove(result);
                            int row = await _context.SaveChangesAsync();
                            if (row > 0)
                            {
                                kq.status = true;
                                kq.msg = "Delete Successfully";
                                return kq;
                            }
                            else
                            {
                                throw new Exception("Delete Failed");
                            }
                        }
                        else
                        {
                            throw new Exception("Not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Find Error");
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

        public async Task<KqJson> deleteSubMenu(DeleteEntityRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if(model.Id > 0)
                    {
                        var result = await _context.subMenuDbs.SingleOrDefaultAsync(p => p.ID_submenu==model.Id);
                        if(result != null)
                        {
                            _context.Remove(result);
                            int row = await _context.SaveChangesAsync();
                            if (row > 0)
                            {
                                kq.status = true;
                                kq.msg = "Delete Successfully";
                                return kq;
                            }
                            else
                            {
                                throw new Exception("delete Failed");
                            }
                        }
                        else
                        {
                            throw new Exception("Not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Find Error");
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

        public async Task<KqJson> editDiadiem(DiadiemRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if (model.ID_diadiem > 0)
                    {
                        var result = await _context.diaDiemDbs.SingleOrDefaultAsync(p=>p.ID_diadiem==model.ID_diadiem);
                        if(result != null)
                        {
                            result.Diadiem_title = model.Diadiem_title!=null?model.Diadiem_title:result.Diadiem_title;
                            result.Diadiem_content = model.Diadiem_content != null ? model.Diadiem_content : result.Diadiem_title;
                            result.Diadiem_summary = model.Diadiem_summary != null ? model.Diadiem_summary : result.Diadiem_title;
                            result.PathImage = model.PathImage != null ? model.PathImage : result.PathImage;
                            result.Longtitude = model.Longtitude != null ? model.Longtitude : result.Longtitude;
                            result.Latitude = model.Latitude != null ? model.Latitude : result.Latitude;
                            result.Submenu_id = model.Submenu_id != null ? model.Submenu_id : result.Submenu_id;
                            result.Number_phone = model.Number_phone != null ? model.Number_phone : result.Number_phone;
                            result.Diachi = model.Diachi != null ? model.Diachi : result.Diachi;

                            int row = await _context.SaveChangesAsync();
                            if(row > 0)
                            {
                                kq.status = true;
                                kq.msg = "Edit Successfully";
                                return kq;
                            }
                            else
                            {
                                throw new Exception("Edit Failed");
                            }
                        }
                        else
                        {
                            throw new Exception("Not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Find Error");
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

        public async Task<KqJson> editMenu(MenuRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if(model != null)
                {
                    if (model.ID_menu != null)
                    {
                        var result = await _context.menuDbs.SingleOrDefaultAsync(p=>p.ID_menu==model.ID_menu);
                        if (result != null)
                        {
                            result.Menu_title = model.Menu_title != null ? model.Menu_title : result.Menu_title;
                            result.PathIcon = model.PathIcon != null ? model.PathIcon : result.PathIcon;

                            int row = await _context.SaveChangesAsync();
                            if (row > 0)
                            {
                                kq.status = true;
                                kq.msg = "Edit Successfully";
                                return kq;
                            }
                            else
                            {
                                throw new Exception("Edit Failed");
                            }
                        }
                        else
                        {
                            throw new Exception("Not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Find Error");
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

        public async Task<KqJson> editSubmenu(SubMenuRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if(model.ID_submenu > 0)
                    {
                        var result = await _context.subMenuDbs.SingleOrDefaultAsync(p=>p.ID_submenu==model.ID_submenu);
                        if (result != null)
                        {
                            result.Submenu_title = model.Submenu_title != null ? model.Submenu_title : result.Submenu_title;
                            result.PathIcon = model.PathIcon != null ? model.PathIcon : result.PathIcon;
                            result.Menu_id = model.Menu_id != null ? model.Menu_id : result.Menu_id;

                            int row = await _context.SaveChangesAsync();
                            if (row > 0)
                            {
                                kq.status = true;
                                kq.msg = "Edit Successfully";
                                return kq;
                            }
                            else
                            {
                                throw new Exception("Edit Failed");
                            }
                        }
                        else
                        {
                            throw new Exception("Not found");
                        }
                    }
                    else
                    {
                        throw new Exception("Find Error");
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
