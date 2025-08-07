using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Domain.Entities
{
    public class Favorite
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        //public DateTime AddedOn { get; set; }
        public bool IsRemoved { get; set; }

        public User User { get; set; }
        public CarModel CarModel { get; set; }
    }
}
