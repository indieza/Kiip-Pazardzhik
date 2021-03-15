// <copyright file="AddRegionalCollege.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddRegionalCollege
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddRegionalCollege.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;

    public class AddRegionalCollegeService : IAddRegionalCollegeService
    {
        private readonly ApplicationDbContext db;

        public AddRegionalCollegeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddRegionalCollege(AddRegionalCollegeInputModel model)
        {
            this.db.RegionalColleges.Add(new RegionalCollege
            {
                DisplayName = model.Name,
                Url = model.Url,
            });
            await this.db.SaveChangesAsync();
        }
    }
}