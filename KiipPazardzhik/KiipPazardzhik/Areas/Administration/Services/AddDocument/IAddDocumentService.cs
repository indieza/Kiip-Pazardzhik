// <copyright file="IAddDocument.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddDocument
{
    using KiipPazardzhik.Areas.Administration.ViewModels.AddDocument.InputModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAddDocumentService
    {
        Task AddDocument(AddDocumentInputModel model);
    }
}