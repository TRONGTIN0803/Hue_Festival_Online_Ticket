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
    public class TintucService:ITintucService
    {
        private readonly Hue_Festival_Context _context;
        private readonly IMapper _mapper;
        public TintucService(Hue_Festival_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<KqJson> changeWishTintuc(YeuthichRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model.User_id > 0 && model.Entity_wish_id > 0)
                {
                    int row = 0;
                    var check_wish = await(from w in _context.tinTucYeuThichDbs
                                           where w.User_id == model.User_id && w.Tintuc_id == model.Entity_wish_id
                                           select w).SingleOrDefaultAsync();
                    if (check_wish == null)
                    {
                        TinTucYeuThichDb model_add = new TinTucYeuThichDb();
                        model_add.User_id = model.User_id;
                        model_add.Tintuc_id = model.Entity_wish_id;
                        model_add.IsWish = true;

                        await _context.tinTucYeuThichDbs.AddAsync(model_add);
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

        public async Task<KqJson> getNewsDetail(int news_id)
        {
            KqJson kq = new KqJson();
            try
            {
                if(news_id > 0)
                {
                    var result = await _context.tinTucDbs.Where(p => p.ID_tintuc == news_id).SingleOrDefaultAsync();
                    if (result != null)
                    {
                        var col=_context.Entry(result);
                        await col.Collection(p => p.list_Image).LoadAsync();
                        List<TinTucImageDb> list_img = new List<TinTucImageDb>();
                        foreach(var img in result.list_Image)
                        {
                            TinTucImageDb image = new TinTucImageDb();
                            image.ID_image = img.ID_image;
                            image.Image_path = img.Image_path;
                            list_img.Add(image);
                        }
                        result.list_Image = list_img;
                        TintucResponeDTO res = new TintucResponeDTO();
                        res = _mapper.Map<TintucResponeDTO>(result);
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
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                kq.data = null;
                return kq;
            }
        }

        public async Task<KqJson> getNewsList()
        {
            KqJson kq = new KqJson();
            try
            {
                var result = await (from tt in _context.tinTucDbs
                                    select new TinTucDb
                                    {
                                        ID_tintuc=tt.ID_tintuc,
                                        Tintuc_title=tt.Tintuc_title,
                                        Tintuc_time=tt.Tintuc_time,
                                        list_Image=tt.list_Image,
                                    }).ToListAsync();
                if (result.Count > 0)
                {
                    foreach(var news in result)
                    {
                        List<TinTucImageDb> list_img = new List<TinTucImageDb>();
                        foreach(var img in news.list_Image)
                        {
                            TinTucImageDb image = new TinTucImageDb();
                            image.ID_image = img.ID_image;
                            image.Image_path = img.Image_path;
                            list_img.Add(image);
                        }
                        news.list_Image = list_img;
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
    }
}
