// <copyright file="NewsViewModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Website.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using OfficeOpenXml.ConditionalFormatting;

    public class SingleNewsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<WebsiteFileViewModel> Files { get; set; } =
            new HashSet<WebsiteFileViewModel>();
    }
}