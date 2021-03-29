// <copyright file="DesignOfficesService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.DesignOffices
{
    using System.Linq;

    using KiipPazardzhik.Data;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public class DesignOfficesService : IDesignOfficesService
    {
        private readonly ApplicationDbContext db;

        public DesignOfficesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public DesignOfficesViewModel GetInformation()
        {
            var result = this.db.DesignOffices.FirstOrDefault();
            return new DesignOfficesViewModel
            {
                Description = result == null ? string.Empty : result.Description,
            };
        }
    }
}