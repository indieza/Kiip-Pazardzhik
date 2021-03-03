// <copyright file="IAddPersonService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddPerson
{
    using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.InputModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAddPersonService
    {
        Task AddPerson(AddPersonInputModel model);
    }
}