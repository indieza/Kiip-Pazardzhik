// <copyright file="IEditInformationService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditInformation
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels;

    public interface IEditInformationService
    {
        EditInformationInputModel GetInformation();

        Task EditInformation(EditInformationInputModel model);
    }
}