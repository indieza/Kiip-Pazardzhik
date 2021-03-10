// <copyright file="FileViewModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.ViewModels.Website.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Models.Enums;

    public class DocumentViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DocumentType DocumentType { get; set; }

        public string Url { get; set; }
    }
}