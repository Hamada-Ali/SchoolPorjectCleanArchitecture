﻿using MailKit.Net.Smtp;
using MimeKit;
using SchoolProject.Domain.Helpers;
using SchoolProject.Services.Interface;


namespace SchoolProject.Services.Implementation
{
    public class EmailsService : IEmailsService
    {
        private readonly EmailSettings _emailSettings;

        public EmailsService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task<string> SendEmail(string email, string Message, string? reason)
        {

            // ##### THIS CODE COPY AND PAST FOR EVERY PROJECT (UNIVERSAL EMAIL SENDER CODE)  - MAILKIT PACKAGE REQUIRED
            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject = reason == null ? "No Submitted" : reason;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
    }
}
