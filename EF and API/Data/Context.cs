using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EF_and_API;

namespace Application.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<EF_and_API.WeatherForecast>? WeatherForecast { get; set; }
    }
}
