using CarStoreApi.Application.DTOS.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Favorite
{
    public class FavoriteDto : BasicCarDto
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
        public string CarBrand { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
