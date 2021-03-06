﻿// <copyright file="DeleteNewsBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.VeiwModels
{
    using System.Collections.Generic;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteNews.InputModels;

    public class DeleteNewsBaseModel
    {
        public DeleteNewsInputModel DeleteNewsInputModel { get; set; }

        public ICollection<DeleteNewsViewModel> AllNews { get; set; } =
            new HashSet<DeleteNewsViewModel>();
    }
}