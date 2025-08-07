using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Domain.Entities
{
    public class Rate
    {
        public Guid UserId { get; set; }
        public Guid CarModelId { get; set; }
        public float RateValue { get; set; }

        public User User { get; set; }
        public CarModel CarModel { get; set; }
    }
}
