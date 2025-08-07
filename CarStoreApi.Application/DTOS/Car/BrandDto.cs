using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Car
{
    public class BrandDto
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string? Logo { get; set; }
    }
}
