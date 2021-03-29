// <copyright file="IInformationService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Information
{
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public interface IInformationService
    {
        InformationViewModel GetInformation();
    }
}