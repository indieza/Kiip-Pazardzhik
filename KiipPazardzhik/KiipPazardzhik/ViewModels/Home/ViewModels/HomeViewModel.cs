// <copyright file="HomeViewModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Home.ViewModels
{
    using System.Collections.Generic;

    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public class HomeViewModel
    {
        public bool HasAdmin { get; internal set; }

        public ICollection<SingleNewsViewModel> TopThreeNews { get; set; } =
            new HashSet<SingleNewsViewModel>();

        public ICollection<SingleNewsViewModel> TopFiveNews { get; set; } =
            new HashSet<SingleNewsViewModel>();
    }
}