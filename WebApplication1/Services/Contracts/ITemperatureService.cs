using WebApplication1.Models;

namespace WebApplication1.Services.Contracts
{
    public interface ITemperatureService
    {
        IEnumerable<Temperature> GetTemperatures();
        Temperature GetTemperatureById(int id);

        void CreateTemperature(Temperature temperature);

        void UpdateTemperature(Temperature temperature);

        void DeleteTemperatureById(int id);

    }
}
