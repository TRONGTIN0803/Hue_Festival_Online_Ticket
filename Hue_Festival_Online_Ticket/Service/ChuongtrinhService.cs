using AutoMapper;
using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.Data;
using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Request;
using Hue_Festival_Online_Ticket.Model.Response;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Hue_Festival_Online_Ticket.Service
{
    public class ChuongtrinhService : IChuongtrinhService
    {
        private readonly Hue_Festival_Context _context;
        private readonly IMapper _mapper;
        public ChuongtrinhService(Hue_Festival_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<KqJson> changeWishProgram(YeuthichRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if(model.User_id>0 && model.Entity_wish_id > 0)
                {
                    int row = 0;
                    var check_wish = await (from w in _context.chuongTrinhYeuThichDbs
                                            where w.User_id == model.User_id && w.Chuongtrinh_id == model.Entity_wish_id
                                            select w).SingleOrDefaultAsync();
                    if (check_wish == null)
                    {
                        ChuongTrinhYeuThichDb model_add = new ChuongTrinhYeuThichDb();
                        model_add.User_id=model.User_id;
                        model_add.Chuongtrinh_id = model.Entity_wish_id;
                        model_add.IsWish = true;

                        await _context.chuongTrinhYeuThichDbs.AddAsync(model_add);
                        row = await _context.SaveChangesAsync();
                        kq.msg = "Da them yeu thich";
                    }
                    else
                    {
                        if (check_wish.IsWish==true)
                        {
                            check_wish.IsWish=false;
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
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> getDetailProgram(int id_program)
        {
            KqJson kq = new KqJson();
            try
            {
                if (id_program > 0)
                {
                    var detail_program = await _context.chuongTrinhDbs.SingleOrDefaultAsync(p => p.ID_chuongtrinh == id_program);
                    
                    if (detail_program != null)
                    {
                        List<DetailChuongtrinhResponeDTO> list_detail = new List<DetailChuongtrinhResponeDTO>();

                        var col = _context.Entry(detail_program);
                        await col.Collection(p => p.list_Image).LoadAsync();
                        List<ChuongTrinhImageDb> list_img = new List<ChuongTrinhImageDb>();
                        foreach (var img in detail_program.list_Image)
                        {
                            ChuongTrinhImageDb images = new ChuongTrinhImageDb();
                            images.ID_image=img.ID_image;
                            images.Image_path = img.Image_path;
                            list_img.Add(images);
                        }
                        detail_program.list_Image = list_img;

                        var list_detail_db = await (from p in _context.chuongTrinhDbs
                                                    join d in _context.diaDiemDbs
                                                    on p.Diadiem_id equals d.ID_diadiem
                                                    where p.ID_chuongtrinh == detail_program.ID_chuongtrinh
                                                    select new
                                                    {
                                                        time = p.Time,
                                                        fdate = p.Fdate,
                                                        tdate = p.Tdate,
                                                        diadiem_id = d.ID_diadiem,
                                                        diadiem_name = d.Diadiem_title,
                                                        id_nhom = p.Nhom_id!=null?p.Nhom_id:0,
                                                        id_doan=p.Doan_id!=null?p.Doan_id : 0
                                                    }).ToListAsync();

                        foreach (var detail in list_detail_db)
                        {
                            DetailChuongtrinhResponeDTO x = new DetailChuongtrinhResponeDTO();
                            if (detail.id_doan != 0)
                            {
                                var doan_name = await (from doan in _context.doanDbs
                                                       where doan.ID_doan == detail.id_doan
                                                       select doan.Doan_name).SingleOrDefaultAsync();
                                x.doan_name = doan_name;
                            }
                            if (detail.id_nhom != 0)
                            {
                                var nhom_name = await (from n in _context.nhomDbs
                                                       where n.ID_nhom == detail.id_nhom
                                                       select n.Nhom_name).SingleOrDefaultAsync();
                                x.nhom_name = nhom_name;
                            }
                            x.time = detail.time;
                            x.fdate = detail.fdate;
                            x.tdate = detail.tdate;
                            x.diadiem_id = detail.diadiem_id;
                            x.diadiem_name = detail.diadiem_name;
                            x.id_nhom = detail.id_nhom;
                            x.id_doan = detail.id_doan;

                            list_detail.Add(x);
                        }


                        ChuongtrinhResponeDTO result = new ChuongtrinhResponeDTO();
                        result = _mapper.Map<ChuongtrinhResponeDTO>(detail_program);
                        result.detail_list = list_detail;
                        kq.status = true;
                        kq.msg = "thanh cong";
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

        public async Task<KqJson> getProgramList(int type_program)
        {
            KqJson kq = new KqJson();
            try
            {
                if(type_program>0 && type_program <= 4)
                {
                    var list_program = await (from ct in _context.chuongTrinhDbs
                                              where ct.Type_program == type_program
                                              select ct).ToListAsync();
                    if(list_program.Count > 0)
                    {
                        foreach(var program in list_program)
                        {
                            var col = _context.Entry(program);
                            await col.Collection(p => p.list_Image).LoadAsync();
                            List<ChuongTrinhImageDb> list_img = new List<ChuongTrinhImageDb>();
                            foreach (var img in program.list_Image)
                            {
                                ChuongTrinhImageDb images = new ChuongTrinhImageDb();
                                images.ID_image = img.ID_image;
                                images.Image_path = img.Image_path;
                                list_img.Add(images);
                            }
                            program.list_Image = list_img;
                        }
                        List<ChuongtrinhResponeDTO> result = new List<ChuongtrinhResponeDTO>();
                        result = _mapper.Map < List<ChuongtrinhResponeDTO>>(list_program);
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

        public async Task<KqJson> getCarlenderList()
        {
            KqJson kq = new KqJson();
            try
            {
                List<CalenderResponeDTO> result = new List<CalenderResponeDTO>();
                for (var i = 0; i <= 10; i++)
                {
                    CalenderResponeDTO cal = new CalenderResponeDTO();
                    var datenow = DateTime.Now.Date.AddDays(i);
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
            }
            catch (Exception e)
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
                else
                {
                    throw new Exception("Ngày không hợp lệ. Ngày có dang'yyyy-mm-dd'");
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

        public async Task<KqJson> editProgram(EditProgramRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
               if(model != null)
                {
                    if(model.ID_chuongtrinh>0)
                    {
                        
                        var result = await _context.chuongTrinhDbs.SingleOrDefaultAsync(p => p.ID_chuongtrinh == model.ID_chuongtrinh);
                        if (result != null)
                        {
                            result.Chuongtrinh_name = model.Chuongtrinh_name != null ? model.Chuongtrinh_name : result.Chuongtrinh_name;
                            result.Chuongtrinh_content = model.Chuongtrinh_content != null ? model.Chuongtrinh_content : result.Chuongtrinh_content;
                            result.Type_inoff = model.Type_inoff != null ? model.Type_inoff : result.Type_inoff;
                            result.Price = model.Price != null ? model.Price : result.Price;
                            result.Type_program = model.Type_program != null ? model.Type_program : result.Type_program;
                            result.Diadiem_id = model.Diadiem_id != null ? model.Diadiem_id : result.Diadiem_id;
                            result.Time = model.Time != null ? model.Time : result.Time;
                            if (model.Fdate != null)
                            {
                                DateTime fngay;
                                if (DateTime.TryParseExact(model.Fdate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fngay))
                                {
                                    result.Fdate = fngay;
                                }
                                else
                                {
                                    throw new Exception("Fdate định dang không phù hợp, 'yyyy-MM-dd'");
                                }
                            }
                            if (model.Tdate != null)
                            {
                                DateTime tngay;
                                if (DateTime.TryParseExact(model.Tdate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tngay))
                                {
                                    result.Tdate = tngay;
                                }
                                else
                                {
                                    throw new Exception("Tdate định dang không phù hợp, 'yyyy-MM-dd'");
                                }
                            }                  
                            result.Nhom_id = model.Nhom_id != null ? model.Nhom_id : result.Nhom_id;
                            result.Doan_id = model.Doan_id != null ? model.Doan_id : result.Doan_id;

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

        public async Task<KqJson> addProgram(EditProgramRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if(model != null)
                {
                    if(model.Chuongtrinh_name!=null && model.Chuongtrinh_content!=null && model.Type_inoff!=null && model.Price!=null
                        && model.Type_program!=null && model.Time!=null && model.Fdate!=null && model.Tdate != null)
                    {
                        ChuongTrinhDb chuongtrinh_add = new ChuongTrinhDb();
                        DateTime fngay,tngay;
                        chuongtrinh_add.Chuongtrinh_name = model.Chuongtrinh_name;
                        chuongtrinh_add.Chuongtrinh_content = model.Chuongtrinh_content;
                        if(model.Type_inoff==1 || model.Type_inoff == 2)
                        {
                            chuongtrinh_add.Type_inoff = model.Type_inoff;
                        }
                        else
                        {
                            throw new Exception("Type_inoff không phù hợp");
                        }
                        if (model.Type_inoff == 1)
                        {
                            chuongtrinh_add.Price = 0;
                        }
                        else
                        {
                            chuongtrinh_add.Price = model.Price;
                        }
                        chuongtrinh_add.Type_program = model.Type_program;
                        chuongtrinh_add.Time = model.Time;
                        if (DateTime.TryParseExact(model.Fdate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fngay))
                        {
                            chuongtrinh_add.Fdate = fngay;
                        }
                        else
                        {
                            throw new Exception("Fdate không đúng định dạng 'yyyy-MM-dd'");
                        }
                        if (DateTime.TryParseExact(model.Tdate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tngay))
                        {
                            chuongtrinh_add.Tdate = tngay;
                        }
                        else
                        {
                            throw new Exception("Tdate không đúng định dạng 'yyyy-MM-dd'");
                        }

                        await _context.chuongTrinhDbs.AddAsync(chuongtrinh_add);
                        int row = await _context.SaveChangesAsync();
                        if (row > 0)
                        {
                            kq.status= true;
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
                        throw new Exception("Hãy nhập đủ name,content,type_inoff,price,type_program,time,fdate,tdate");
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

        public async Task<KqJson> deleteProgram(DeleteEntityRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if(model != null)
                {
                    if(model.Id >0)
                    {
                        var result = await _context.chuongTrinhDbs.SingleOrDefaultAsync(p=>p.ID_chuongtrinh==model.Id);
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
                                throw new Exception("Delete failed");
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
                    throw new Exception("Bad Request");
                }
            }catch(Exception e)
            {
                kq.status = false;
                kq.msg= e.Message;
                return kq;
            }
        }

        public async Task<KqJson> historyProgram()
        {
            KqJson kq = new KqJson();
            try
            {
                var date = DateTime.Now;
                var list_program = await (from p in _context.chuongTrinhDbs
                                     where p.Tdate < date
                                     orderby p.Tdate descending
                                     select p).ToListAsync();
                if (list_program.Count > 0)
                {
                    foreach (var program in list_program)
                    {
                        var col = _context.Entry(program);
                        await col.Collection(p => p.list_Image).LoadAsync();
                        List<ChuongTrinhImageDb> list_img = new List<ChuongTrinhImageDb>();
                        foreach (var img in program.list_Image)
                        {
                            ChuongTrinhImageDb images = new ChuongTrinhImageDb();
                            images.ID_image = img.ID_image;
                            images.Image_path = img.Image_path;
                            list_img.Add(images);
                        }
                        program.list_Image = list_img;
                    }
                    List<ChuongtrinhResponeDTO> result = new List<ChuongtrinhResponeDTO>();
                    result = _mapper.Map<List<ChuongtrinhResponeDTO>>(list_program);
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
            catch(Exception e)
            {
                kq.status = false;
                kq.msg = e.Message;
                return kq;
            }
        }

        public async Task<KqJson> addImage(AddImageRequestDTO model)
        {
            KqJson kq = new KqJson();
            try
            {
                if (model != null)
                {
                    if (model.Entity_id > 0)
                    {
                        if (model.List_pathimage.Count > 0)
                        {
                            List<ChuongTrinhImageDb> list_img = new List<ChuongTrinhImageDb>();
                            foreach (var image in model.List_pathimage)
                            {
                                ChuongTrinhImageDb img = new ChuongTrinhImageDb();
                                img.Image_path = image;
                                img.Chuongtrinh_id = model.Entity_id;
                                list_img.Add(img);
                            }
                            await _context.chuongTrinhImageDbs.AddRangeAsync(list_img);
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
