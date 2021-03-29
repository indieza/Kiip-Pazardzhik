// <copyright file="IContactService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Contact
{
    using KiipPazardzhik.ViewModels.Contacts.InputModels;

    public interface IContactService
    {
        void SendEmail(ContactsInputModel model);
    }
}