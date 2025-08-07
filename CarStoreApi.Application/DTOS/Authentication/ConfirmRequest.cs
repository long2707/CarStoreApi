using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Authentication
{
    public class ConfirmRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
