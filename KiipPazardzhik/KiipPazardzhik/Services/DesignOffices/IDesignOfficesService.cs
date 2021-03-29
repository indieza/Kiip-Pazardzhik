// <copyright file="IDesignOfficesService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.DesignOffices
{
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public interface IDesignOfficesService
    {
        DesignOfficesViewModel GetInformation();
    }
}