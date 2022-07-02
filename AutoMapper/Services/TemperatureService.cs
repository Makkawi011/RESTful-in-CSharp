using AutoMapper.Data;
using AutoMapper.Models;
using AutoMapper.Services.Contracts;

namespace AutoMapper.Services
{
    public class TemperatureService : ITemperatureService
    {
        private readonly Context context;

        public TemperatureService(Context context)
        {
            this.context = context;
        }

        public void CreateTemperature(Temperature temperature)
        {
            context.Add(temperature);

            context.SaveChanges();
        }

        public void DeleteTemperatureById(int id)
        {
            var oldTemp = context.Temperature.Find(id);
            context.Temperature.Remove(oldTemp);
            context.SaveChanges();

        }

        public Temperature GetTemperatureById(int id) => context.Temperature.Find(id);

        public IEnumerable<Temperature> GetTemperatures() => context.Temperature;
        

        public void UpdateTemperature(Temperature newTemperature)
        {
            var oldTemp = context.Temperature.Find(newTemperature.Id);
            oldTemp.TemperatureC = newTemperature.TemperatureC;

            context.SaveChanges();
        }
    }
}
