using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.User
{
    public class UserDto : BasicUserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
