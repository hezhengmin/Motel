﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Infrastructure.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Infrastructure.Data
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
        public virtual DbSet<OccupiedRoom> OccupiedRoom { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomState> RoomState { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }

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

            modelBuilder.Entity<OccupiedRoom>(entity =>
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
                    .WithMany(p => p.OccupiedRoom)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Occupy_Customer");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.OccupiedRoom)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OccupiedRoom_Room");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasComment("預訂日期");

                entity.Property(e => e.CheckIn).HasComment("");

                entity.Property(e => e.Days).HasComment("天數/小時");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("預訂者姓名");

                entity.Property(e => e.RoomId).HasComment("");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("預訂者電話");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Customer");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Room");
            });

            modelBuilder.Entity<Room>(entity =>
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

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomType");
            });

            modelBuilder.Entity<RoomState>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.State).HasComment("狀態");

                entity.Property(e => e.Type).HasComment("種類");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RoomState)
                    .HasForeignKey<RoomState>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomState_Room");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}