﻿// <copyright file="DeleteDocumentBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.ViewModels
{
    using System.Collections.Generic;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.InputModels;

    public class DeleteDocumentBaseModel
    {
        public DeleteDocumentInputModel DeleteDocumentInputModel { get; set; }

        public ICollection<DeleteDocumentViewModel> AllDocuments { get; set; } =
            new HashSet<DeleteDocumentViewModel>();
    }
}