// <copyright file="IEditPersonService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditPerson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.ViewModels;

    public interface IEditPersonService
    {
        ICollection<EditPersonViewModel> GetAllPeople();

        Task<GetPersonDataViewModel> GetPersonById(string personId);

        Task EditPerson(EditPersonInputModel model);
    }
}