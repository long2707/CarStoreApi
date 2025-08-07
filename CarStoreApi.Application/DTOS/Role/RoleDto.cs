using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Application.DTOS.Role
{
    public class RoleDto : AddRoleDto
    {
        public Guid RoleId { get; set; }
        public List<string> UserNames { get; set; }
    }
}
