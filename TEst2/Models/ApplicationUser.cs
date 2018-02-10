using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TEst2.Models
{
    public class PermittedRole
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public bool IsPermitted { get; set; }
    }

    public class ApplicationUser: IdentityUser
    {        
        [MaxLength(50)]
        public String FirstName { get; set; }

        [MaxLength(50)]
        public String LastName { get; set; }

        public bool IsApproved { get; set; } // подтвердил менеджер или нет

        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public List<PermittedRole> Roles { get; set; }

        public virtual ICollection<ImportFileInfo> ImportFileInfo { get; set; }
    }
}
