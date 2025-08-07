using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Rate
{
    public class RateDto : AddRateDto
    {
        public double AverageRate { get; set; }
    }
}
