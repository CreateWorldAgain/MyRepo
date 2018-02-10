using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TEst2.Models.ViewModels;
using TEst2.Services;

namespace TEst2.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailInfoAboutApproveAsync(this IEmailSender emailSender, string email, string subject, string htmlEmailText)
        {
            string error = emailSender.SendEmail(email, subject, htmlEmailText);
            return Task.CompletedTask;
        }

        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string subject, string htmlEmailText)
        {
            string error=emailSender.SendEmail(email, subject, htmlEmailText);
            return Task.CompletedTask;
        }

        public static Task SendEmailForConfirmationUserAsync(this IEmailSender emailSender, string email, string subject, string htmlEmailText)
        {
            string error = emailSender.SendEmail(email, subject, htmlEmailText);
            return Task.CompletedTask;
        }

    }
}
