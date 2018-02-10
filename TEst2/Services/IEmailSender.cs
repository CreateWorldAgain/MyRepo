using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEst2.Services
{
    public interface IEmailSender
    {
        String SendEmail(string email, string subject, string message);
    }
}
