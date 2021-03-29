// <copyright file="AllNewsViewModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.News.ViewModels
{
    using System.Collections.Generic;

    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public class AllNewsViewModel
    {
        public ICollection<SingleNewsViewModel> AllNews { get; set; } =
            new HashSet<SingleNewsViewModel>();
    }
}