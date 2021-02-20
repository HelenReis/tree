using System;
using System.Collections.Generic;
using System.Text;

namespace Tree.Service.Queries.Helpers
{
    static internal class HelperQueries
    {
        static public Domain.Models.Enums.StatusSafetyColorEnum 
            ReturnStatusSafetyColorByValues(short temperature, short humidity)
        {
            switch (temperature)
            {
                case short temp when temp < 34 && humidity > 14:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Green;
                case short temp when temp > 34 && humidity > 14:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Yellow;
                case short temp when temp > 34 && humidity < 14:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Red;
                default:
                    return Domain.Models.Enums.StatusSafetyColorEnum.Green;
            }
        }
    }
}
