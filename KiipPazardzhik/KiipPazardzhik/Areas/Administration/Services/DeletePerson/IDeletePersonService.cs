// <copyright file="IDeletePersonService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeletePerson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.ViewModels;

    public interface IDeletePersonService
    {
        ICollection<DeletePersonViewModel> GetAllPeople();

        Task DeletePerson(DeletePersonInputModel model);
    }
}