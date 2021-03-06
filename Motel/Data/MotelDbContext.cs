﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Motel.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Motel.Data
{
    public partial class MotelDbContext : DbContext
    {
        public MotelDbContext()
        {
        }

        public MotelDbContext(DbContextOptions<MotelDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<GuestRoom> GuestRoom { get; set; }
        public virtual DbSet<Occupy> Occupy { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<RoomState> RoomState { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D1CFQGS\\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(256)
                    .HasComment("客戶住址");

                entity.Property(e => e.Birthday)
                    .HasColumnType("date")
                    .HasComment("客戶生日");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasComment("電子郵件");

                entity.Property(e => e.Gender).HasComment("性別");

                entity.Property(e => e.IdentityNum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("身份證字號");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("客戶姓名");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("客戶電話");
            });

            modelBuilder.Entity<GuestRoom>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Describe)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("房間位置");

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("房間描述");

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("房間號碼");

                entity.Property(e => e.RoomTypeId).HasComment("指定房屋類別");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.GuestRoom)
                    .HasForeignKey<GuestRoom>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GuestRoom_RoomState");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.GuestRoom)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GuestRoom_RoomType");
            });

            modelBuilder.Entity<Occupy>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasComment("訂房時間");

                entity.Property(e => e.Days).HasComment("天數/小時");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasComment("實際退房時間");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("房間號");

                entity.Property(e => e.OccupyType).HasComment("訂房type值");

                entity.Property(e => e.Pay)
                    .HasColumnType("money")
                    .HasComment("結算金額");

                entity.Property(e => e.PlanEndDate)
                    .HasColumnType("datetime")
                    .HasComment("預計退房時間");

                entity.Property(e => e.PrePay)
                    .HasColumnType("money")
                    .HasComment("已付金額");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasComment("房間價格");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Occupy)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Occupy_Customer");

                entity.HasOne(d => d.GusetRoom)
                    .WithMany(p => p.Occupy)
                    .HasForeignKey(d => d.GusetRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Occupy_GuestRoom");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasComment("預訂日期");

                entity.Property(e => e.Days).HasComment("天數/小時");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("預訂者姓名");

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0000')")
                    .HasComment("房間號碼");

                entity.Property(e => e.RoomTypeId).HasComment("指定房屋類別");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("預訂者電話");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_RoomType");
            });

            modelBuilder.Entity<RoomState>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.State).HasComment("狀態");

                entity.Property(e => e.Type).HasComment("種類");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AirCondition).HasComment("是否有空調");

                entity.Property(e => e.Area).HasComment("房間面積");

                entity.Property(e => e.BedQuantity).HasComment("配備床數");

                entity.Property(e => e.Hprice)
                    .HasColumnName("HPrice")
                    .HasColumnType("money")
                    .HasComment("假日價");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("類型名稱");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasComment("平日價");

                entity.Property(e => e.Qk2price)
                    .HasColumnName("QK2Price")
                    .HasColumnType("money")
                    .HasComment("休息價(元/2hr)");

                entity.Property(e => e.Qkprice)
                    .HasColumnName("QKPrice")
                    .HasColumnType("money")
                    .HasComment("休息價(元/3hr)");

                entity.Property(e => e.Tv)
                    .HasColumnName("TV")
                    .HasComment("是否有電視");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("使用者名稱");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("地址");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .HasComment("工作部門");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("電子郵件");

                entity.Property(e => e.Gender).HasComment("性別");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("員工姓名");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("密碼");

                entity.Property(e => e.Power).HasComment("員工類型");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("員工電話");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
