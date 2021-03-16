// <copyright file="IInformationService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Information
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public interface IInformationService
    {
        InformationViewModel GetInformation();
    }
}