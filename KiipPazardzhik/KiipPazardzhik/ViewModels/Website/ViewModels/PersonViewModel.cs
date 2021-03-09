// <copyright file="PersonViewModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Website.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PersonViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }

        public string TechnicalControl { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string RegisterNumber { get; set; }

        public string Section { get; set; }

        public string LegalCapacity { get; set; }

        public bool IsFrozen { get; set; }

        public bool IsActive { get; set; }
    }
}