# 汽車旅館管理系統

網站連結：https://motel.azurewebsites.net

## 使用技術

* Html、CSS
* Bootstrap 4
* JavaScript / jQuery
* C# 
* Azure App Service
* MSSQL

## 汽車旅館管理系統的資料庫綱要
資料庫共有 7 個資料表，其資料庫圖表如下圖所示：

* Customer 資料表是儲存旅館的客戶資料
* Room 資料表是旅館的房間資料，每一間房間都擁有一筆記錄
* RoomType 資料表的記錄資料是旅館房間類型
* RoomState 資料表是儲存房間狀態資料
* Reservation 資料表是儲存旅館的預訂資料
* OccupiedRoom 資料表是旅館入住記錄，客戶每一次入住，都會在資料表新增一筆記錄
* User 資料表是儲存系統的使用者資料，包含登入和員工的基本資料 **(功能尚未實作)**

![Diagram_Motel](https://user-images.githubusercontent.com/17740845/120467312-a42ea180-c3d2-11eb-94ee-9b3a7c4f7bea.jpg)

## 備註 
#### Infrastructure類別庫，NuGet安裝
1. Microsoft.EntityFrameworkCore.SqlServer
2. Microsoft.EntityFrameworkCore.Tools

#### Application類別庫，NuGet安裝     
1. AutoMapper.Extensions.Microsoft.DependencyInjection

[工具] > [NuGet 套件管理員] > [套件管理器主控台] 
#### 新增特定資料表
``` C#
Scaffold-DbContext "Data Source=DESKTOP-D1CFQGS\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -contextdir Data -outputdir Models -context MotelDbContext -tables Customer, Room, OccupiedRoom, RoomState, Reservation, RoomType
```


#### 強制更新特定資料表
    PM> Scaffold-DbContext "Data Source=DESKTOP-D1CFQGS\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -contextdir Data -outputdir Models -context MotelDbContext -tables Customer, Room, OccupiedRoom, RoomState, User, Reservation, RoomType -Force

#### 建立第一個移轉
Add-Migration InitialCreate
#### 移轉結構描述
Update-Database
