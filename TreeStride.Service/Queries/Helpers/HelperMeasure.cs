using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.Service.Queries.Helpers
{
    static internal class HelperMeasure
    {
        public static Domain.Models.Enums.StatusSafetyColorEnum 
            ReturnStatusSafetyColorByValues(short temperature, short humidity)
        {
            var measure = AngstronMeasure(temperature, humidity);

            switch (measure)
            {
                case double temp when temp < 2.5:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Red;
                case double temp when temp == 2.5:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Yellow;
                case double temp when temp > 2.5:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Green;
                default:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Not_Identified;
            }
        }

        private static double AngstronMeasure(short temperature, short humidity)
        {
            var b = 0.05 * humidity - 0.1 * (temperature - 27);
            return b;
        }
    }
}
