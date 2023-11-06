﻿// <auto-generated />
using System;
using Hue_Festival_Online_Ticket.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hue_Festival_Online_Ticket.Migrations
{
    [DbContext(typeof(Hue_Festival_Context))]
    [Migration("20231105085650_createDb_V3")]
    partial class createDb_V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.ChuongTrinhDb", b =>
                {
                    b.Property<int>("ID_chuongtrinh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_chuongtrinh"), 1L, 1);

                    b.Property<string>("Chuongtrinh_content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chuongtrinh_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Diadiem_id")
                        .HasColumnType("int");

                    b.Property<int?>("Doan_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Nhom_id")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Tdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type_inoff")
                        .HasColumnType("int");

                    b.Property<int?>("Type_program")
                        .HasColumnType("int");

                    b.HasKey("ID_chuongtrinh");

                    b.HasIndex("Diadiem_id");

                    b.HasIndex("Doan_id");

                    b.HasIndex("Nhom_id");

                    b.ToTable("Chuongtrinh");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.ChuongTrinhImageDb", b =>
                {
                    b.Property<int>("ID_image")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_image"), 1L, 1);

                    b.Property<int?>("Chuongtrinh_id")
                        .HasColumnType("int");

                    b.Property<string>("Image_path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_image");

                    b.HasIndex("Chuongtrinh_id");

                    b.ToTable("ChuongtrinhImage");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.ChuongTrinhYeuThichDb", b =>
                {
                    b.Property<int>("ID_chuongtrinh_yeuthich")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_chuongtrinh_yeuthich"), 1L, 1);

                    b.Property<int?>("Chuongtrinh_id")
                        .HasColumnType("int");

                    b.Property<bool?>("IsWish")
                        .HasColumnType("bit");

                    b.Property<int?>("User_id")
                        .HasColumnType("int");

                    b.HasKey("ID_chuongtrinh_yeuthich");

                    b.HasIndex("Chuongtrinh_id");

                    b.HasIndex("User_id");

                    b.ToTable("ChuongtrinhYeuthich");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DiaDiemDb", b =>
                {
                    b.Property<int>("ID_diadiem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_diadiem"), 1L, 1);

                    b.Property<string>("Diachi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diadiem_content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diadiem_summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diadiem_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longtitude")
                        .HasColumnType("float");

                    b.Property<string>("Number_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Submenu_id")
                        .HasColumnType("int");

                    b.HasKey("ID_diadiem");

                    b.HasIndex("Submenu_id");

                    b.ToTable("Diadiem");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DiaDiemSoatVeDb", b =>
                {
                    b.Property<int>("ID_diadiem_soatve")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_diadiem_soatve"), 1L, 1);

                    b.Property<int?>("Chuongtrinh_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("End_time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Start_time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_diadiem_soatve");

                    b.HasIndex("Chuongtrinh_id");

                    b.ToTable("DiadiemSoatve");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DiaDiemYeuThichDb", b =>
                {
                    b.Property<int>("ID_diadiem_yeuthich")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_diadiem_yeuthich"), 1L, 1);

                    b.Property<int?>("Diadiem_id")
                        .HasColumnType("int");

                    b.Property<bool?>("IsWish")
                        .HasColumnType("bit");

                    b.Property<int?>("User_id")
                        .HasColumnType("int");

                    b.HasKey("ID_diadiem_yeuthich");

                    b.HasIndex("Diadiem_id");

                    b.HasIndex("User_id");

                    b.ToTable("DiaDiemYeuThichDb");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DoanDb", b =>
                {
                    b.Property<int>("ID_doan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_doan"), 1L, 1);

                    b.Property<string>("Doan_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_doan");

                    b.ToTable("Doan");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.HoTroDb", b =>
                {
                    b.Property<int>("ID_hotro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_hotro"), 1L, 1);

                    b.Property<string>("Hotro_content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotro_title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_hotro");

                    b.ToTable("Hotro");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.HoTroUserDb", b =>
                {
                    b.Property<int>("ID_hotro_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_hotro_user"), 1L, 1);

                    b.Property<int?>("Hotro_id")
                        .HasColumnType("int");

                    b.Property<int?>("User_id")
                        .HasColumnType("int");

                    b.HasKey("ID_hotro_user");

                    b.HasIndex("Hotro_id");

                    b.HasIndex("User_id");

                    b.ToTable("HotroUser");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.MenuDb", b =>
                {
                    b.Property<int>("ID_menu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_menu"), 1L, 1);

                    b.Property<string>("Menu_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathIcon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_menu");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.NhomDb", b =>
                {
                    b.Property<int>("ID_nhom")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_nhom"), 1L, 1);

                    b.Property<string>("Nhom_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_nhom");

                    b.ToTable("Nhom");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.SubMenuDb", b =>
                {
                    b.Property<int>("ID_submenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_submenu"), 1L, 1);

                    b.Property<int?>("Menu_id")
                        .HasColumnType("int");

                    b.Property<string>("PathIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Submenu_title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_submenu");

                    b.HasIndex("Menu_id");

                    b.ToTable("Submenu");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.TinTucDb", b =>
                {
                    b.Property<int>("ID_tintuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_tintuc"), 1L, 1);

                    b.Property<string>("Tintuc_content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Tintuc_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tintuc_title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_tintuc");

                    b.ToTable("Tintuc");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.TinTucImageDb", b =>
                {
                    b.Property<int>("ID_image")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_image"), 1L, 1);

                    b.Property<string>("Image_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Tintuc_id")
                        .HasColumnType("int");

                    b.HasKey("ID_image");

                    b.HasIndex("Tintuc_id");

                    b.ToTable("TintucImage");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.TinTucYeuThichDb", b =>
                {
                    b.Property<int>("ID_wish_tintuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_wish_tintuc"), 1L, 1);

                    b.Property<bool?>("IsWish")
                        .HasColumnType("bit");

                    b.Property<int?>("Tintuc_id")
                        .HasColumnType("int");

                    b.Property<int?>("User_id")
                        .HasColumnType("int");

                    b.HasKey("ID_wish_tintuc");

                    b.HasIndex("Tintuc_id");

                    b.HasIndex("User_id");

                    b.ToTable("TintucYeuthich");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.UserDb", b =>
                {
                    b.Property<int>("ID_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_user"), 1L, 1);

                    b.Property<string>("User_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User_role")
                        .HasColumnType("int");

                    b.HasKey("ID_user");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.VeDb", b =>
                {
                    b.Property<int>("ID_ve")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_ve"), 1L, 1);

                    b.Property<int?>("Chuongtrinh_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date_soatve")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NV_soatve")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("User_id")
                        .HasColumnType("int");

                    b.HasKey("ID_ve");

                    b.HasIndex("Chuongtrinh_id");

                    b.HasIndex("User_id");

                    b.ToTable("Ve");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.ChuongTrinhDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.DiaDiemDb", "Diadiem")
                        .WithMany("list_Chuongtrinh")
                        .HasForeignKey("Diadiem_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhDb_Diadiem");

                    b.HasOne("Hue_Festival_Online_Ticket.Data.DoanDb", "Doan")
                        .WithMany("list_Chuongtrinh")
                        .HasForeignKey("Doan_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhDb_Doan");

                    b.HasOne("Hue_Festival_Online_Ticket.Data.NhomDb", "Nhom")
                        .WithMany("list_Chuongtrinh")
                        .HasForeignKey("Nhom_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhDb_Nhom");

                    b.Navigation("Diadiem");

                    b.Navigation("Doan");

                    b.Navigation("Nhom");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.ChuongTrinhImageDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.ChuongTrinhDb", "Chuongtrinh")
                        .WithMany("list_Image")
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhImageDb_Chuongtrinh");

                    b.Navigation("Chuongtrinh");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.ChuongTrinhYeuThichDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.ChuongTrinhDb", "Chuongtrinh")
                        .WithMany("list_ChuongTrinhYeuThichDb")
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhYeuThichDb_Chuongtrinh");

                    b.HasOne("Hue_Festival_Online_Ticket.Data.UserDb", "User")
                        .WithMany("list_ChuongtrinhYeuthich")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_ChuongTrinhYeuThichDb_User");

                    b.Navigation("Chuongtrinh");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DiaDiemDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.SubMenuDb", "Submenu")
                        .WithMany("list_Diadiem")
                        .HasForeignKey("Submenu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_DiaDiemDb_Submenu");

                    b.Navigation("Submenu");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DiaDiemSoatVeDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.ChuongTrinhDb", "Chuongtrinh")
                        .WithMany("list_DiaDiemSoatVe")
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_DiaDiemSoatVeDb_Chuongtrinh");

                    b.Navigation("Chuongtrinh");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DiaDiemYeuThichDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.DiaDiemDb", "Diadiem")
                        .WithMany("list_Diadiemyeuthich")
                        .HasForeignKey("Diadiem_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_DiaDiemYeuThichDb_Diadiem");

                    b.HasOne("Hue_Festival_Online_Ticket.Data.UserDb", "User")
                        .WithMany("list_Diadiemyeuthich")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_DiaDiemYeuThichDb_User");

                    b.Navigation("Diadiem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.HoTroUserDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.HoTroDb", "Hotro")
                        .WithMany("list_HotroUser")
                        .HasForeignKey("Hotro_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_HoTroUserDb_Hotro");

                    b.HasOne("Hue_Festival_Online_Ticket.Data.UserDb", "User")
                        .WithMany("list_HotroUser")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_HoTroUserDb_User");

                    b.Navigation("Hotro");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.SubMenuDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.MenuDb", "Menu")
                        .WithMany("list_Submenu")
                        .HasForeignKey("Menu_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_SubMenuDb_Menu");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.TinTucImageDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.TinTucDb", "Tintuc")
                        .WithMany("list_Image")
                        .HasForeignKey("Tintuc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TinTucImageDb_TinTuc");

                    b.Navigation("Tintuc");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.TinTucYeuThichDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.TinTucDb", "TinTuc")
                        .WithMany("list_TintucYeuthich")
                        .HasForeignKey("Tintuc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TinTucYeuThichDb_TinTuc");

                    b.HasOne("Hue_Festival_Online_Ticket.Data.UserDb", "User")
                        .WithMany("list_TintucYeuthich")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_TinTucYeuThichDb_User");

                    b.Navigation("TinTuc");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.VeDb", b =>
                {
                    b.HasOne("Hue_Festival_Online_Ticket.Data.ChuongTrinhDb", "Chuongtrinh")
                        .WithMany("list_Ve")
                        .HasForeignKey("Chuongtrinh_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_VeDb_Chuongtrinh");

                    b.HasOne("Hue_Festival_Online_Ticket.Data.UserDb", "User")
                        .WithMany("list_Ve")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_VeDb_User");

                    b.Navigation("Chuongtrinh");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.ChuongTrinhDb", b =>
                {
                    b.Navigation("list_ChuongTrinhYeuThichDb");

                    b.Navigation("list_DiaDiemSoatVe");

                    b.Navigation("list_Image");

                    b.Navigation("list_Ve");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DiaDiemDb", b =>
                {
                    b.Navigation("list_Chuongtrinh");

                    b.Navigation("list_Diadiemyeuthich");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.DoanDb", b =>
                {
                    b.Navigation("list_Chuongtrinh");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.HoTroDb", b =>
                {
                    b.Navigation("list_HotroUser");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.MenuDb", b =>
                {
                    b.Navigation("list_Submenu");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.NhomDb", b =>
                {
                    b.Navigation("list_Chuongtrinh");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.SubMenuDb", b =>
                {
                    b.Navigation("list_Diadiem");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.TinTucDb", b =>
                {
                    b.Navigation("list_Image");

                    b.Navigation("list_TintucYeuthich");
                });

            modelBuilder.Entity("Hue_Festival_Online_Ticket.Data.UserDb", b =>
                {
                    b.Navigation("list_ChuongtrinhYeuthich");

                    b.Navigation("list_Diadiemyeuthich");

                    b.Navigation("list_HotroUser");

                    b.Navigation("list_TintucYeuthich");

                    b.Navigation("list_Ve");
                });
#pragma warning restore 612, 618
        }
    }
}
