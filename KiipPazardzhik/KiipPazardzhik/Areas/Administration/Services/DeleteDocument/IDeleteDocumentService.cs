// <copyright file="IDeleteDocumentService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeleteDocument
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteDocument.ViewModels;

    public interface IDeleteDocumentService
    {
        ICollection<DeleteDocumentViewModel> GetAllDocuments();

        Task DeleteDocument(DeleteDocumentInputModel model);
    }
}