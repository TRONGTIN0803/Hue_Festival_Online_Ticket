using AutoMapper;
using Hue_Festival_Online_Ticket.Context;
using Hue_Festival_Online_Ticket.Data;
using Hue_Festival_Online_Ticket.IService;
using Hue_Festival_Online_Ticket.Model;
using Hue_Festival_Online_Ticket.Model.Response;
using Microsoft.EntityFrameworkCore;

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
                            images.Image_path = img.Image_path;
                            list_img.Add(images);
                        }
                        detail_program.list_Image = list_img;

                        var list_detail_db = await (from ld in _context.lichDienDbs
                                                    join n in _context.nhomDbs
                                                    on ld.Nhom_id equals n.ID_nhom
                                                    join p in _context.chuongTrinhDbs
                                                    on ld.Chuongtrinh_id equals p.ID_chuongtrinh
                                                    join d in _context.diaDiemDbs
                                                    on p.Diadiem_id equals d.ID_diadiem
                                                    where ld.Chuongtrinh_id == detail_program.ID_chuongtrinh
                                                    select new
                                                    {
                                                        time = ld.Time,
                                                        fdate = ld.Fdate,
                                                        tdate = ld.Tdate,
                                                        diadiem_id = d.ID_diadiem,
                                                        diadiem_name = d.Diadiem_title,
                                                        id_nhom = n.ID_nhom,
                                                        nhom_name = n.Nhom_name,
                                                    }).ToListAsync();
                        foreach (var detail in list_detail_db)
                        {
                            DetailChuongtrinhResponeDTO x = new DetailChuongtrinhResponeDTO();
                            x.time = detail.time;
                            x.fdate = detail.fdate;
                            x.tdate = detail.tdate;
                            x.diadiem_id = detail.diadiem_id;
                            x.diadiem_name = detail.diadiem_name;
                            x.id_nhom = detail.id_nhom;
                            x.nhom_name = detail.nhom_name;

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
                            foreach(var image in program.list_Image)
                            {
                                ChuongTrinhImageDb imgRespone = new ChuongTrinhImageDb();
                                image.Image_path= imgRespone.Image_path;
                                list_img.Add(imgRespone);
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
    }
}
