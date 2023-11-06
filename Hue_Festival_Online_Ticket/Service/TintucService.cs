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

        public async Task<KqJson> addImage(AddImageRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if(model.Entity_id>0)
                    {
                        if (model.List_pathimage.Count > 0)
                        {
                            List<TinTucImageDb> list_img = new List<TinTucImageDb>();
                            foreach(var image in model.List_pathimage)
                            {
                                TinTucImageDb img = new TinTucImageDb();
                                img.Image_path = image;
                                img.Tintuc_id = model.Entity_id;
                                list_img.Add(img);
                            }
                            await _context.tinTucImageDbs.AddRangeAsync(list_img);
                            int row = await _context.SaveChangesAsync();
                            if (row > 0)
                            {
                                kq.status = true;
                                kq.msg = "Add Succesfully";
                                return kq;
                            }
                            else
                            {
                                throw new Exception("Add Failed");
                            }
                        }
                        else
                        {
                            throw new Exception("Phải có ít nhất 1 ảnh");
                        }
                    }
                    else
                    {
                        throw new Exception("ID không phù hợp");
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

        public async Task<KqJson> addNews(TintucRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if(model.Tintuc_title!=null && model.Tintuc_content != null)
                    {
                        TinTucDb tintuc = new TinTucDb();
                        tintuc.Tintuc_title = model.Tintuc_title;
                        tintuc.Tintuc_content = model.Tintuc_content;
                        tintuc.Tintuc_time = DateTime.Now;

                        await _context.tinTucDbs.AddAsync(tintuc);
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

        public async Task<KqJson> deleteNews(DeleteEntityRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if (model.Id > 0)
                    {
                        var resulrt = await _context.tinTucDbs.SingleOrDefaultAsync(p => p.ID_tintuc == model.Id);
                        if (resulrt != null)
                        {
                            _context.Remove(resulrt);
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

        public async Task<KqJson> editNews(TintucRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if(model != null)
                {
                    if (model.ID_tintuc > 0)
                    {
                        var result = await _context.tinTucDbs.SingleOrDefaultAsync(p => p.ID_tintuc == model.ID_tintuc);
                        if (result != null)
                        {
                            result.Tintuc_title = model.Tintuc_title != null ? model.Tintuc_title : result.Tintuc_title;
                            result.Tintuc_content = model.Tintuc_content != null ? model.Tintuc_content : result.Tintuc_content;
                            result.Tintuc_time = DateTime.Now;

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
