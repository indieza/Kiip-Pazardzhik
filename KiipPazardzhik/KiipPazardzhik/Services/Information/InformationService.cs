// <copyright file="InformationService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Information
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Data;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public class InformationService : IInformationService
    {
        private readonly ApplicationDbContext db;

        public InformationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public InformationViewModel GetInformation()
        {
            var result = this.db.Information.FirstOrDefault();
            return new InformationViewModel
            {
                Description = result == null ? string.Empty : result.Description,
            };
        }
    }
}