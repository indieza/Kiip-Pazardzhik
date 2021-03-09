// <copyright file="GetSectionByNameBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Register.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public class GetSectionByNameBaseModel
    {
        public string SectionName { get; set; }

        public ICollection<PersonViewModel> AllPeople { get; set; } =
            new HashSet<PersonViewModel>();
    }
}