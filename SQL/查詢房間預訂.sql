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
	  ,O.[Days] as OccupiedRoom_Days
	  ,O.[Balance]
      ,[Expense]
      ,R.[SysDate]
  FROM [Motel].[dbo].[Reservation] R
  join [Room] RM on RM.[Id]  = R.[RoomId]
  join [RoomType] RT on RT.[Id] = RM.[RoomTypeId]
  join [Customer] C on C.[Id] = R.[CustomerId]
  left join [OccupiedRoom] O on O.Id = R.Id
  where R.Id = '4D59E1D0-1C7F-46E6-80B5-C44A9B9118F4'
  order by [BeginDate] desc

