SELECT TOP (1000) R.[Id]
      ,RM.[RoomNumber]
	  ,RT.[Name]
	  ,C.[Name]
	  ,[CheckInDate]
      ,[CheckOutDate]
      ,[BeginDate]
      ,[EndDate]
      ,R.[Days]
	  ,O.[Pay]
      ,[Expense]
      ,R.[SysDate]
  FROM [Motel].[dbo].[Reservation] R
  join [Room] RM on RM.[Id]  = R.[RoomId]
  join [RoomType] RT on RT.[Id] = RM.[RoomTypeId]
  join [Customer] C on C.[Id] = R.[CustomerId]
  join [OccupiedRoom] O on O.Id = R.Id
  order by [BeginDate] desc

