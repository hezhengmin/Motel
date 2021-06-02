# 汽車旅館管理系統
> 汽車旅館管理系統是使用 ASP.NET 技術（C#語言），搭配資料庫(MSSQL)建立的 Web 應用程式，可以作為小型旅館或汽車旅館的櫃台管理系統，專案目前按照官網教學中的[ASP.NET Core MVC 使用者入門](https://docs.microsoft.com/zh-tw/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-3.1&tabs=visual-studio)來做網頁程式開發，最終部署到Azure平台上。

網站連結：https://motel.azurewebsites.net

![Azure網站房間截圖](https://user-images.githubusercontent.com/17740845/120481294-89642900-c3e2-11eb-94b1-aee8a876ffe0.jpg)

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
#### ASP.NET Core 3.1 如何使用 Database First
> [工具] > [NuGet 套件管理員] > [套件管理器主控台] ，若資料庫有更新，則後面可以加上`-Force`
``` C#
Scaffold-DbContext "Data Source=DESKTOP-D1CFQGS\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -contextdir Data -outputdir Models -context MotelDbContext -tables Customer, Room, OccupiedRoom, RoomState, User, Reservation, RoomType
```    
#### EF Core migrations feature
| EF Core 移轉功能 | Commands |
| ------------- | -----:|
| 建立第一個移轉 | Add-Migration InitialCreate |
| 移轉結構描述 | Update-Database |
## 參考
1. https://github.com/EduardoPires/EquinoxProject 
2. https://github.com/AutoMapper/AutoMapper
3. 資料庫系統理論與實務(第四版)
4. [ASP.NET Core 文件](https://docs.microsoft.com/zh-tw/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-3.1)
5. [jQuery Ajax CRUD Operations with Asp.NET Core Mvc](https://github.com/CodAffection/jQuery-Ajax-with-ASP.NET-Core-MVC-using-Modal-PopUp)
