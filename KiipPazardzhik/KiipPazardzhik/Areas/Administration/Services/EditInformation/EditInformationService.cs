// <copyright file="EditInformationService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditInformation
{
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels;
    using KiipPazardzhik.Data;

    using Microsoft.EntityFrameworkCore;

    public class EditInformationService : IEditInformationService
    {
        private readonly ApplicationDbContext db;

        public EditInformationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task EditInformation(EditInformationInputModel model)
        {
            var targetInfromation = await this.db.Information.FirstOrDefaultAsync(x => x.Id == model.Id);
            targetInfromation.Description = model.SanitizedDescription;
            this.db.Information.Update(targetInfromation);
            await this.db.SaveChangesAsync();
        }

        public EditInformationInputModel GetInformation()
        {
            return this.db.Information
                .Select(x => new EditInformationInputModel
                {
                    Id = x.Id,
                    Description = x.Description,
                })
                .FirstOrDefault();
        }
    }
}