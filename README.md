# Motel
#### �s�WInfrastructure���O�w�ANuGet�w��
1. Microsoft.EntityFrameworkCore.SqlServer
2. Microsoft.EntityFrameworkCore.Tools

#### �s�WApplication���O�w�ANuGet�w��     
1. AutoMapper.Extensions.Microsoft.DependencyInjection

#### �s�W�S�w��ƪ�
    PM> Scaffold-DbContext "Data Source=DESKTOP-D1CFQGS\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -contextdir Data -outputdir Models -context MotelDbContext -tables Customer, Room, OccupiedRoom, RoomState, Reservation, RoomType

#### �j���s�S�w��ƪ�
    Scaffold-DbContext "Data Source=DESKTOP-D1CFQGS\SQLEXPRESS;Initial Catalog=Motel;User ID=sa;Password=123456" Microsoft.EntityFrameworkCore.SqlServer -contextdir Data -outputdir Models -context MotelDbContext -tables Customer, Room, OccupiedRoom, RoomState, User, Reservation, RoomType -Force
