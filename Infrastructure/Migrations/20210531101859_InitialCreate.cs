using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    IdentityNum = table.Column<string>(unicode: false, maxLength: 10, nullable: false, comment: "身份證字號"),
                    Gender = table.Column<int>(nullable: false, comment: "性別"),
                    Name = table.Column<string>(maxLength: 10, nullable: false, comment: "客戶姓名"),
                    Address = table.Column<string>(maxLength: 256, nullable: true, comment: "客戶住址"),
                    Tel = table.Column<string>(unicode: false, maxLength: 20, nullable: false, comment: "客戶電話"),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "系統日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 20, nullable: false, comment: "類型名稱"),
                    Area = table.Column<double>(nullable: false, comment: "房間面積"),
                    BedQuantity = table.Column<int>(nullable: false, comment: "配備床數"),
                    Price = table.Column<int>(nullable: false, comment: "平日價"),
                    HPrice = table.Column<int>(nullable: false, comment: "假日價"),
                    AirCondition = table.Column<bool>(nullable: false, comment: "是否有空調"),
                    TV = table.Column<bool>(nullable: false, comment: "是否有電視"),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "系統日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(unicode: false, maxLength: 10, nullable: false, comment: "使用者名稱"),
                    Password = table.Column<string>(unicode: false, maxLength: 20, nullable: false, comment: "密碼"),
                    Name = table.Column<string>(maxLength: 10, nullable: false, comment: "員工姓名"),
                    Gender = table.Column<int>(nullable: false, comment: "性別"),
                    Address = table.Column<string>(maxLength: 50, nullable: false, comment: "地址"),
                    Tel = table.Column<string>(unicode: false, maxLength: 20, nullable: false, comment: "員工電話"),
                    Email = table.Column<string>(unicode: false, maxLength: 30, nullable: false, comment: "電子郵件"),
                    Department = table.Column<string>(maxLength: 50, nullable: true, comment: "工作部門"),
                    Power = table.Column<int>(nullable: false, comment: "員工類型")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    RoomNumber = table.Column<string>(unicode: false, maxLength: 10, nullable: false, comment: "房間號碼"),
                    RoomTypeId = table.Column<Guid>(nullable: false, comment: "指定房屋類別"),
                    Describe = table.Column<string>(maxLength: 50, nullable: true, comment: "房間位置"),
                    Position = table.Column<string>(maxLength: 50, nullable: true, comment: "房間描述"),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "系統日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_RoomType",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    RoomId = table.Column<Guid>(nullable: false, comment: ""),
                    CustomerId = table.Column<Guid>(nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "預訂入住日期"),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "預訂退房時間"),
                    Days = table.Column<int>(nullable: false, comment: "天數"),
                    Expense = table.Column<int>(nullable: false, comment: "住宿費"),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "系統日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomState",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StateType = table.Column<int>(nullable: false, comment: "房間狀態")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomState_Room",
                        column: x => x.Id,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OccupiedRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "實際入住時間"),
                    CheckOutDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "實際退房時間"),
                    Pay = table.Column<int>(nullable: true, comment: "結算金額"),
                    SysDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(sysdatetime())", comment: "系統日期")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupiedRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occupy_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OccupiedRoom_Reservation",
                        column: x => x.Id,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OccupiedRoom_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OccupiedRoom_CustomerId",
                table: "OccupiedRoom",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupiedRoom_RoomId",
                table: "OccupiedRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId",
                table: "Reservation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OccupiedRoom");

            migrationBuilder.DropTable(
                name: "RoomState");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
