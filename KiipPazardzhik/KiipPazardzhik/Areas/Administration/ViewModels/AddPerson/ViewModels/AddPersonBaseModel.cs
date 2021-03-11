// <copyright file="AddPersonBaseModel.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.ViewModels
{
    using System.Collections.Generic;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.InputModels;

    public class AddPersonBaseModel
    {
        public ICollection<string> AllSections { get; set; } =
            new HashSet<string>();

        public ICollection<string> AllPositions { get; set; } =
            new HashSet<string>();

        public ICollection<string> AllTechnicalControls { get; set; } =
            new HashSet<string>();

        public ICollection<string> AllLegalCapacities { get; set; } =
            new HashSet<string>();

        public AddPersonInputModel AddPersonInputModel { get; set; }
    }
}