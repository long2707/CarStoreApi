using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Domain.Entities
{
    public class CarBrand
    {
        [Key]
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string? Logo { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
