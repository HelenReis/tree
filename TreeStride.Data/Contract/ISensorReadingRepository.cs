using System.Linq;
using System.Threading.Tasks;
using Tree.Domain.Models;

namespace Tree.Data.Contract
{
    public interface ISensorReadingRepository
    {
        void Create(SensorReading sensorReading);

        void Update(SensorReading sensorReading);

        void Delete(SensorReading sensorReading);

        Task<SensorReading> GetById(int sensorReading);

        Task<bool> AnyAsync(int sensorReadingId);

        IQueryable<SensorReading> Query();
    }
}
