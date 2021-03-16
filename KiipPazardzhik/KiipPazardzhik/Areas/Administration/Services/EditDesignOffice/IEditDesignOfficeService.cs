// <copyright file="IEditDesignOfficeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditDesignOffice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels;

    public interface IEditDesignOfficeService
    {
        EditDesignOfficeInputModel GetInformation();

        Task EditInformation(EditDesignOfficeInputModel model);
    }
}