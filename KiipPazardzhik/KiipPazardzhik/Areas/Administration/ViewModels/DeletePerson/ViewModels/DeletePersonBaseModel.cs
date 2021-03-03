// <copyright file="DeletePersonBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.InputModels;

    public class DeletePersonBaseModel
    {
        public DeletePersonInputModel DeletePersonInputModel { get; set; }

        public ICollection<DeletePersonViewModel> AllPeople { get; set; } =
            new HashSet<DeletePersonViewModel>();
    }
}