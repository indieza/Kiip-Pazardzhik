// <copyright file="EditPersonBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.ViewModels
{
    using System.Collections.Generic;

    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.InputModels;

    public class EditPersonBaseModel
    {
        public EditPersonInputModel EditPersonInputModel { get; set; }

        public ICollection<EditPersonViewModel> AllPeople { get; set; } =
            new HashSet<EditPersonViewModel>();

        public ICollection<string> AllSections { get; set; } =
            new HashSet<string>();

        public ICollection<string> AllPositions { get; set; } =
            new HashSet<string>();

        public ICollection<string> AllTechnicalControls { get; set; } =
            new HashSet<string>();
    }
}