using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Domain.Entities
{
    public class CarFeatures
    {
        public Guid CarModelId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsDeleted { get; set; }

        public CarModel CarModel { get; set; }
        public Feature Feature { get; set; }
    }
}
