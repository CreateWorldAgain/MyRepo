using System.ComponentModel.DataAnnotations;

namespace TEst2.Controllers
{
  
        public class ForgotPasswordViewModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }
    }
