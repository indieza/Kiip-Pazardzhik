// <copyright file="IAddInfromationService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddInfromation
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels;

    public interface IAddInformationService
    {
        bool HaveInformationAlready();

        Task AddInformation(AddInformationInputModel model);
    }
}