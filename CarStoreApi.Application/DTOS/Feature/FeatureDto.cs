using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Feature
{
    public class FeatureDto : AddFeatureDto
    {
        public Guid FeatureId { get; set; }
    }
}
