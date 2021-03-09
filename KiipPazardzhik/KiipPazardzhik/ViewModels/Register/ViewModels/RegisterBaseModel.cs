// <copyright file="RegisterBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Register.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography.Xml;
    using System.Threading.Tasks;

    public class RegisterBaseModel
    {
        public ICollection<RegisterViewModel> AllSections { get; set; } =
            new HashSet<RegisterViewModel>();
    }
}