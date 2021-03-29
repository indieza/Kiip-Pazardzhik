// <copyright file="IEditDesignOfficeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditDesignOffice
{
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels;

    public interface IEditDesignOfficeService
    {
        EditDesignOfficeInputModel GetInformation();

        Task EditInformation(EditDesignOfficeInputModel model);
    }
}