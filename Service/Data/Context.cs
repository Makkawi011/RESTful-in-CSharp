using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service;

namespace Service.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Service.WeatherForecast>? WeatherForecast { get; set; }
    }
}
