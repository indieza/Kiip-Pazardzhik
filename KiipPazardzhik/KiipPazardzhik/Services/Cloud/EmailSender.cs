﻿// <copyright file="EmailSender.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Cloud
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Configuration;

    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return this.Execute(this.configuration.GetSection("SendGrid:ApiKey").Value, email, subject, htmlMessage);
        }

        private Task Execute(string apiKey, string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress("simeonvalev00@gmail.com", "Sharemundo Bulgaria Administration"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage,
            };

            message.AddTo(new EmailAddress(email));
            message.SetClickTracking(false, false);
            return client.SendEmailAsync(message);
        }
    }
}