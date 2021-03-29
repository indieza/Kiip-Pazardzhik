// <copyright file="IDocumentsService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Documents
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public interface IDocumentsService
    {
        Dictionary<string, List<DocumentViewModel>> GetAllDocuments();

        Task<Tuple<byte[], string>> GetFile(string id);
    }
}