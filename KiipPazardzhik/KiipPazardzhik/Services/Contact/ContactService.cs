// <copyright file="ContactService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Contact
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.ViewModels.Contacts.InputModels;

    using Microsoft.Extensions.Configuration;

    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class ContactService : IContactService
    {
        private readonly IConfiguration configuration;

        public ContactService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendEmail(ContactsInputModel model)
        {
            this.Execute(model).Wait();
        }

        private async Task Execute(ContactsInputModel model)
        {
            var apiKey = this.configuration.GetSection("SendGrid:ApiKey").Value;
            var client = new SendGridClient(apiKey);

            var message = new SendGridMessage()
            {
                From = new EmailAddress(model.Email, model.FullName),
                Subject = model.Title,
                PlainTextContent = model.Description,
                HtmlContent = $"<strong>Hello, KIIP Pazardzhik Administrators!</strong><br />{model.Description}",
            };

            message.AddTo(new EmailAddress("kiippz@mail.bg", "Test User"));
            var response = await client.SendEmailAsync(message);
        }
    }
}