// <copyright file="RegisterBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Register.ViewModels
{
    using System.Collections.Generic;

    public class RegisterBaseModel
    {
        public ICollection<RegisterViewModel> AllSections { get; set; } =
            new HashSet<RegisterViewModel>();
    }
}