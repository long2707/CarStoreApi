using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Car
{
    public class CarDto : BasicCarDto
    {
        public Guid CarId { get; set; }
        public string CarBrand { get; set; }
        public List<string>? ImagesUrls { get; set; }
        public bool IsLiked { get; set; }
    }
}
