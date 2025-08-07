using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Car
{
    public class UpdateCarDto : BasicCarDto
    {
        public Guid CarBrandId { get; set; }
    }
}
