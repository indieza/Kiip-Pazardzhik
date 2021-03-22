// <copyright file="IContactService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Contact
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.ViewModels.Contacts.InputModels;

    public interface IContactService
    {
        void SendEmail(ContactsInputModel model);
    }
}