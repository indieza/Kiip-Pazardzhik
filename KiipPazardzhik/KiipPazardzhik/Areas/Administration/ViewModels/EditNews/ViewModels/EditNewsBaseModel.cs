// <copyright file="EditNewsBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.EditNews.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditNews.InputModels;

    public class EditNewsBaseModel
    {
        public EditNewsInputModel EditNewsInputModel { get; set; }

        public ICollection<EditNewsViewModel> AllNews { get; set; } =
            new HashSet<EditNewsViewModel>();
    }
}