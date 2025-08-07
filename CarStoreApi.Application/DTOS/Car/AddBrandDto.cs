using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Car
{
    public class AddBrandDto
    {
        public string BrandName { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
