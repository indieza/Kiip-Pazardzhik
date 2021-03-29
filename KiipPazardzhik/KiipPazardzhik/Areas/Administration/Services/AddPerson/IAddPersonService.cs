// <copyright file="IAddPersonService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddPerson
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.InputModels;

    public interface IAddPersonService
    {
        Task AddPerson(AddPersonInputModel model);

        ICollection<string> GetAllSections();

        ICollection<string> GetAllPosition();

        ICollection<string> GetAllTechnicalControls();

        ICollection<string> GetAllLegalCapacities();
    }
}