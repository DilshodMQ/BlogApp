using Microsoft.AspNetCore.Identity;
using MvcApp.Areas.Identity.Data;

namespace MvcApp.Models
    {
        public class RoleEdit
        {
            public IdentityRole Role { get; set; }
            public IEnumerable<MvcAppUser> Members { get; set; }
            public IEnumerable<MvcAppUser> NonMembers { get; set; }
        }
    }

