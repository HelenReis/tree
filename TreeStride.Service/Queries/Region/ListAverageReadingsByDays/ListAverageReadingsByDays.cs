using Flunt.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Tree.Data.Contract;
using Tree.Domain.DTOs;
using Tree.Domain.Models;
using Tree.Domain.Models.Enums;
using Tree.Service.Queries.Helpers;

namespace Tree.Service.Queries.Region.ListAverageReadingsByDays
{
    public class ListAverageReadingsByDays : IRequestHandler<ParamListAverageReadingsByDays, ResponseListAverageReadingsByDays>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IRegionRepository _regionRepository;
        private List<Notification> _notifications = new List<Notification>();

        public ListAverageReadingsByDays(IDeviceRepository deviceRepository, IRegionRepository regionRepository)
        {
            _deviceRepository = deviceRepository;
            _regionRepository = regionRepository;
        }

        public async Task<ResponseListAverageReadingsByDays> Handle(ParamListAverageReadingsByDays request, CancellationToken cancellationToken)
        {
            try
            {
                var devicesIds = await DevicesIdsByRegion(request.RegionId);

                if (_notifications.Any())
                    return new ResponseListAverageReadingsByDays(
                        null, HttpStatusCode.OK, _notifications);

                var sensorReadings = await SensorReadings(devicesIds, request.Days);

                if (_notifications.Any())
                    return new ResponseListAverageReadingsByDays(
                        null, HttpStatusCode.OK, _notifications);

                return AverageByDays(sensorReadings: sensorReadings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private async Task<IEnumerable<int>> DevicesIdsByRegion(int regionId)
        {
            var devicesIds = await _regionRepository
                .Query()
                .Where(r => r.Id == regionId)
                .Include(r => r.Devices)
                .Select(d => d.Devices.Select(d => d.Id))
                .FirstOrDefaultAsync();

            if (devicesIds == null)
                _notifications.Add(new Notification("RegionId", "It must be an existing region."));

            return devicesIds;
        }

        private async Task<IEnumerable<SensorReading>> SensorReadings(IEnumerable<int> devicesId, int days)
        {
            var finalDate = DateTime.Now;
            var initialDate = finalDate.AddDays(-(days));

            var sensorReadings = await _deviceRepository
                .Query()
                .Where(d => devicesId.Contains(d.Id))
                .Include(d => d.SensorReadings)
                .Select(d => d.SensorReadings
                    .Where(s => s.Date.CompareTo(finalDate) < 0 &&
                        s.Date.CompareTo(initialDate) > 0))
                .FirstOrDefaultAsync();

            if (sensorReadings == null)
                _notifications.Add(new Notification("Devices", "No devices for this region."));

            if (sensorReadings != null && !sensorReadings.Any())
                _notifications.Add(new Notification("SensorReading", "No readings for this device."));

            return sensorReadings;
        }

        private ResponseListAverageReadingsByDays AverageByDays(IEnumerable<Domain.Models.SensorReading> sensorReadings)
        {
            var averageTemperature = (short)(sensorReadings
                .Aggregate(0, (acc, s) => acc + s.Temperature) / sensorReadings.Count());

            var averageHumidity = (short)(sensorReadings
                .Aggregate(0, (acc, s) => acc + s.Humidity) / sensorReadings.Count());

            var angstronMeasure = HelperMeasure
                    .ReturnStatusSafetyColorByValues(
                        temperature: averageTemperature,
                        humidity: averageHumidity);

            var regionAverageReadings = new RegionAverageSensorReadingDTO(
                temperature: averageTemperature,
                humidity: averageHumidity,
                statusSafetyColor: angstronMeasure,
                message: Message(angstronMeasure));

            var result = new ResponseListAverageReadingsByDays(
                regionAverageReadings, HttpStatusCode.OK);

            return result;
        }

        private string Message(StatusSafetyColorEnum status)
        {
            switch (status)
            {
                case StatusSafetyColorEnum.Red:
                    return "Red - Endangered region!";
                case StatusSafetyColorEnum.Yellow:
                    return "Yellow - Keep an eye";
                case StatusSafetyColorEnum.Green:
                    return "Green - Uff. Everything is fine!";
                default:
                    return "Situation not found! Please contact for support.";
            }
        }
    }
}
