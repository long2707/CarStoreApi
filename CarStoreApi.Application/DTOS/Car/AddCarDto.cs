using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Car
{
    public class AddCarDto : BasicCarDto
    {
        public List<IFormFile> Images { get; set; }
        public Guid CarBrandId { get; set; }
    }
}
