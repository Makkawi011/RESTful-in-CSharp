using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Temperature>? Temperature { get; set; }

        public DbSet<WeatherForecast>? WeatherForecast { get; set; }
    }
}
