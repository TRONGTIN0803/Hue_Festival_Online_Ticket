using Hue_Festival_Online_Ticket.Data;
using Microsoft.EntityFrameworkCore;

namespace Hue_Festival_Online_Ticket.Context
{
    public class Hue_Festival_Context : DbContext
    {
        public Hue_Festival_Context(DbContextOptions<Hue_Festival_Context> options) : base(options)
        {

        }

        public DbSet<ChuongTrinhDb> chuongTrinhDbs { get; set; }
        public DbSet<ChuongTrinhImageDb> chuongTrinhImageDbs { get; set; }
        public DbSet<ChuongTrinhYeuThichDb> chuongTrinhYeuThichDbs { get; set; }
        public DbSet<DiaDiemDb> diaDiemDbs { get; set; }
        public DbSet<DiaDiemSoatVeDb> diaDiemSoatVeDbs { get; set; }
        public DbSet<DoanDb> doanDbs { get; set; }
        public DbSet<HoTroDb> hoTroDbs { get; set; }
        public DbSet<HoTroUserDb> hoTroUserDbs { get; set; }
        public DbSet<LichDienDb> lichDienDbs { get; set; }
        public DbSet<MenuDb> menuDbs { get; set; }
        public DbSet<NhomDb> nhomDbs { get; set; }
        public DbSet<SubMenuDb> subMenuDbs { get; set; }
        public DbSet<TinTucDb> tinTucDbs { get; set; }
        public DbSet<TinTucImageDb> tinTucImageDbs { get; set; }
        public DbSet<TinTucYeuThichDb> tinTucYeuThichDbs { get; set; }
        public DbSet<UserDb> userDbs { get; set; }
        public DbSet<VeDb> veDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HoTroUserDb>(entity => {
                
                entity.HasOne(e => e.User)
                        .WithMany(user => user.list_HotroUser)
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_HoTroUserDb_User");

            });
            modelBuilder.Entity<HoTroUserDb>(entity => {

                entity.HasOne(e => e.Hotro)
                        .WithMany(ht => ht.list_HotroUser)
                        .HasForeignKey("Hotro_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_HoTroUserDb_Hotro");

            });
            modelBuilder.Entity<TinTucYeuThichDb>(entity => {

                entity.HasOne(e => e.User)
                        .WithMany(user => user.list_TintucYeuthich)
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TinTucYeuThichDb_User");

            });
            modelBuilder.Entity<TinTucYeuThichDb>(entity => {

                entity.HasOne(e => e.TinTuc)
                        .WithMany(tt => tt.list_TintucYeuthich)
                        .HasForeignKey("Tintuc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TinTucYeuThichDb_TinTuc");

            });
            modelBuilder.Entity<TinTucImageDb>(entity => {

                entity.HasOne(e => e.Tintuc)
                        .WithMany(tt => tt.list_Image)
                        .HasForeignKey("Tintuc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TinTucImageDb_TinTuc");

            });
            modelBuilder.Entity<ChuongTrinhYeuThichDb>(entity => {

                entity.HasOne(e => e.User)
                        .WithMany(user => user.list_ChuongtrinhYeuthich)
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhYeuThichDb_User");

            });
            modelBuilder.Entity<ChuongTrinhYeuThichDb>(entity => {

                entity.HasOne(e => e.Chuongtrinh)
                        .WithMany(ct => ct.list_ChuongTrinhYeuThichDb)
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhYeuThichDb_Chuongtrinh");

            });
            modelBuilder.Entity<VeDb>(entity => {

                entity.HasOne(e => e.User)
                        .WithMany(user => user.list_Ve)
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_VeDb_User");

            });
            modelBuilder.Entity<VeDb>(entity => {

                entity.HasOne(e => e.Chuongtrinh)
                        .WithMany(ct => ct.list_Ve)
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_VeDb_Chuongtrinh");

            });
            modelBuilder.Entity<ChuongTrinhDb>(entity => {

                entity.HasOne(e => e.Diadiem)
                        .WithMany(dd => dd.list_Chuongtrinh)
                        .HasForeignKey("Diadiem_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhDb_Diadiem");

            });
            modelBuilder.Entity<DiaDiemSoatVeDb>(entity => {

                entity.HasOne(e => e.Chuongtrinh)
                        .WithMany(ct => ct.list_DiaDiemSoatVe)
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_DiaDiemSoatVeDb_Chuongtrinh");

            });
            modelBuilder.Entity<ChuongTrinhImageDb>(entity => {

                entity.HasOne(e => e.Chuongtrinh)
                        .WithMany(dd => dd.list_Image)
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhImageDb_Chuongtrinh");

            });
            modelBuilder.Entity<DiaDiemDb>(entity => {

                entity.HasOne(e => e.Submenu)
                        .WithMany(s => s.list_Diadiem)
                        .HasForeignKey("Submenu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_DiaDiemDb_Submenu");

            });
            modelBuilder.Entity<SubMenuDb>(entity => {

                entity.HasOne(e => e.Menu)
                        .WithMany(m => m.list_Submenu)
                        .HasForeignKey("Menu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_SubMenuDb_Menu");

            });
            modelBuilder.Entity<LichDienDb>(entity => {

                entity.HasOne(e => e.Chuongtrinh)
                        .WithMany(ct => ct.list_Lichdien)
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_LichDienDb_Chuongtrinh");

            });
            modelBuilder.Entity<LichDienDb>(entity => {

                entity.HasOne(e => e.Nhom)
                        .WithMany(n => n.list_Lichdien)
                        .HasForeignKey("Nhom_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_LichDienDb_Nhom");

            });
            modelBuilder.Entity<LichDienDb>(entity => {

                entity.HasOne(e => e.Doan)
                        .WithMany(d => d.list_Lichdien)
                        .HasForeignKey("Doan_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_LichDienDb_Doan");

            });
        }
    }
}
