using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using THPCore.Interfaces;
using System.Text.RegularExpressions;

namespace THPCore.Senders;

public class EmailSender(IConfiguration _configuration) : IEmailSender
{
    public async Task<string> SendAsync(string receiver, string subject, string message)
    {
        try
        {
            if (!IsValidEmail(receiver)) return string.Empty;

            var password = _configuration["Settings:EmailPassword"];
            var sender = _configuration["Settings:EmailSender"];
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(sender)) return string.Empty;
            var senderEmail = new MailAddress(sender, "Trường Đại Học Hải Phòng");
            var receiverEmail = new MailAddress(receiver);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            await smtp.SendMailAsync(mess);
            return string.Empty;
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
    }

    /// <summary>
    /// Validates whether a string is a valid email address.
    /// </summary>
    /// <param name="email">The email address to validate.</param>
    /// <returns>True if the email is valid; otherwise, false.</returns>
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Use a regular expression to validate email format
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }
        catch
        {
            return false; // Return false if an exception occurs
        }
    }
}
