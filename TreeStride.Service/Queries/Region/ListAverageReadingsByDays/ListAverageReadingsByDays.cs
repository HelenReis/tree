using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Domain.DTOs;
using Tree.Service.Queries.Helpers;

namespace Tree.Service.Queries.Region.ListAverageReadingsByDays
{
    public class ListAverageReadingsByDays : IRequestHandler<ParamListAverageReadingsByDays, ResponseListAverageReadingsByDays>
    {
        private readonly IDeviceRepository _deviceRepository;

        public ListAverageReadingsByDays(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<ResponseListAverageReadingsByDays> Handle(ParamListAverageReadingsByDays request, CancellationToken cancellationToken)
        {
            try
            {
                var finalDate = DateTime.Now;
                var initialDate = finalDate.AddDays(-(request.Days));

                var sensorReadings = await _deviceRepository
                    .Query()
                    .Include(d => d.SensorReadings)
                    .Select(d => d.SensorReadings
                        .Where(s => s.Date.CompareTo(finalDate) < 0 && 
                            s.Date.CompareTo(initialDate) > 0))
                    .FirstOrDefaultAsync();

                return AverageByDays(sensorReadings: sensorReadings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private ResponseListAverageReadingsByDays AverageByDays(IEnumerable<Domain.Models.SensorReading> sensorReadings)
        {

            var averageTemperature = (short)(sensorReadings
                .Aggregate(0, (acc, s) => acc + s.Temperature)/sensorReadings.Count());

            var averageHumidity = (short)(sensorReadings
                .Aggregate(0, (acc, s) => acc + s.Humidity)/sensorReadings.Count());

            var result = new ResponseListAverageReadingsByDays(
                new RegionAverageSensorReadingDTO(
                    temperature: averageTemperature,
                    humidity: averageHumidity,
                    statusSafetyColor: HelperQueries
                        .ReturnStatusSafetyColorByValues(
                            temperature: averageTemperature,
                            humidity: averageHumidity)
                    ));

            return result;
        }
    }
}
