// <copyright file="EditPersonBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.InputModels;

    public class EditPersonBaseModel
    {
        public EditPersonInputModel EditPersonInputModel { get; set; }

        public ICollection<EditPersonViewModel> AllPeople { get; set; } =
            new HashSet<EditPersonViewModel>();
    }
}