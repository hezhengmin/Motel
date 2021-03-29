# Motel
#### 新增Infrastructure類別庫，NuGet安裝
1. Microsoft.EntityFrameworkCore.SqlServer
2. Microsoft.EntityFrameworkCore.Tools

#### 新增Application類別庫，NuGet安裝     
1. AutoMapper.Extensions.Microsoft.DependencyInjection

#### 新增特定資料表
    PM> Scaffold-DbContext "Data Source=DESKTOP-D1CFQGS\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -contextdir Data -outputdir Models -context MotelDbContext -tables Customer, Room, OccupiedRoom, RoomState, Reservation, RoomType

#### 強制更新特定資料表
    Scaffold-DbContext "Data Source=DESKTOP-D1CFQGS\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -contextdir Data -outputdir Models -context MotelDbContext -tables Customer, Room, OccupiedRoom, RoomState, User, Reservation, RoomType -Force
