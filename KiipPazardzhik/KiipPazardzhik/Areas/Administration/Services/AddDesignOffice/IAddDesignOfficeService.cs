// <copyright file="IAddDesignOfficeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddDesignOffice
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels;

    public interface IAddDesignOfficeService
    {
        bool HaveDesignOfficeAlready();

        Task AddDesignOffice(AddDesignOfficeInputModel model);
    }
}