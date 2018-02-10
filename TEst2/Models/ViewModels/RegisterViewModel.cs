using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEst2.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string Login { get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
