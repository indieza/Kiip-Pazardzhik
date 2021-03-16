// <copyright file="EditDesignOfficeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditDesignOffice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DesignOffice.InputModels;
    using KiipPazardzhik.Data;

    using Microsoft.EntityFrameworkCore;

    public class EditDesignOfficeService : IEditDesignOfficeService
    {
        private readonly ApplicationDbContext db;

        public EditDesignOfficeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task EditInformation(EditDesignOfficeInputModel model)
        {
            var targetInformation = await this.db.DesignOffices.FirstOrDefaultAsync(x => x.Id == model.Id);
            targetInformation.Description = model.SanitizedDescription;
            this.db.DesignOffices.Update(targetInformation);
            await this.db.SaveChangesAsync();
        }

        public EditDesignOfficeInputModel GetInformation()
        {
            return this.db.DesignOffices
                .Select(x => new EditDesignOfficeInputModel
                {
                    Id = x.Id,
                    Description = x.Description,
                })
                .FirstOrDefault();
        }
    }
}