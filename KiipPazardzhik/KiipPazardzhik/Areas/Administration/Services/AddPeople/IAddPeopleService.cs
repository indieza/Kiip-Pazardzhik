// <copyright file="IAddPeopleService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddPeople
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddPeople.InputModels;

    public interface IAddPeopleService
    {
        Task AddPeople(AddPeopleInputModel model);

        MemoryStream CreateTemplate();
    }
}