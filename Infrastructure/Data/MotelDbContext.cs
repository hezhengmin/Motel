﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Infrastructure.Models;
using Infrastructure.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

                var converterGenderType = new ValueConverter<GenderType, int>(
                                v => (int)v,
                                v => (GenderType)Enum.Parse(typeof(GenderType), v.ToString()));

                entity.Property(e => e.Gender)
                      .HasComment("性別")
                      .HasConversion(converterGenderType);

                entity.Property(e => e.IdentityNum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("身份證字號");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("客戶姓名");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasComment("系統日期");

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("客戶電話");
            });

            modelBuilder.Entity<OccupiedRoom>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("datetime")
                    .HasComment("實際入住時間");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("datetime")
                    .HasComment("實際退房時間");

                entity.Property(e => e.Pay).HasComment("結算金額");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())")
                    .HasComment("系統日期");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OccupiedRoom)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Occupy_Customer");

                entity.HasOne(d => d.Reservation)
                    .WithOne(p => p.OccupiedRoom)
                    .HasForeignKey<OccupiedRoom>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OccupiedRoom_Reservation");

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
                    .HasComment("預訂入住日期");

                entity.Property(e => e.Days).HasComment("天數");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasComment("預訂退房時間");

                entity.Property(e => e.Expense).HasComment("住宿費");

                entity.Property(e => e.RoomId).HasComment("");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasComment("系統日期");

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
                    .HasComment("房間位置");

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .HasComment("房間描述");

                entity.Property(e => e.RoomNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("房間號碼");

                entity.Property(e => e.RoomTypeId).HasComment("指定房屋類別");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasComment("系統日期");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomType");
            });

            modelBuilder.Entity<RoomState>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                var converterStateType = new ValueConverter<StateType, int>(
                                v => (int)v,
                                v => (StateType)Enum.Parse(typeof(StateType), v.ToString()));

                entity.Property(e => e.StateType)
                      .HasComment("房間狀態")
                      .HasConversion(converterStateType);

                entity.HasOne(d => d.Room)
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
                    .HasComment("假日價");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("類型名稱");

                entity.Property(e => e.Price).HasComment("平日價");

                entity.Property(e => e.SysDate)
                    .HasColumnType("datetime")
                    .HasComment("系統日期");

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
