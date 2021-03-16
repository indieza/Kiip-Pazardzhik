// <copyright file="AddDesignOfficeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddDesignOffice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;

    public class AddDesignOfficeService : IAddDesignOfficeService
    {
        private readonly ApplicationDbContext db;

        public AddDesignOfficeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddDesignOffice(AddDesignOfficeInputModel model)
        {
            this.db.DesignOffices.Add(new DesignOffice
            {
                Description = model.SanitizedDescription,
            });
            await this.db.SaveChangesAsync();
        }

        public bool HaveDesignOfficeAlready()
        {
            return this.db.DesignOffices.Count() > 0;
        }
    }
}