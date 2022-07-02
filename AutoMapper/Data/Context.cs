using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Models;

namespace AutoMapper.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<AutoMapper.Models.Temperature>? Temperature { get; set; }

        public DbSet<AutoMapper.Models.WeatherForecast>? WeatherForecast { get; set; }
    }
}
