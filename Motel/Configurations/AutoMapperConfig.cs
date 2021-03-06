﻿using Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Motel.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddAutoMapper(typeof(RoomTypeProfile));
            services.AddAutoMapper(typeof(RoomProfile));
            services.AddAutoMapper(typeof(ReservationProfile));
            services.AddAutoMapper(typeof(RoomStateProfile));
            services.AddAutoMapper(typeof(OccupiedRoomProfile));
        }
    }
}
