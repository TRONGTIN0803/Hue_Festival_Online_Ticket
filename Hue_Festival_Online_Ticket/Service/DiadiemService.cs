using AutoMapper;
using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.Data;
using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model;
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
    }
}
