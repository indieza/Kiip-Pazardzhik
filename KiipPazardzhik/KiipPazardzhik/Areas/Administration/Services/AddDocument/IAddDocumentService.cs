// <copyright file="IAddDocument.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddDocument
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddDocument.InputModels;

    public interface IAddDocumentService
    {
        Task AddDocument(AddDocumentInputModel model);
    }
}