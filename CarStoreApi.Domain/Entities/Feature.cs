using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Domain.Entities
{
    public class Feature
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CarFeatures> CarFeatures { get; set; } 
    }
}
