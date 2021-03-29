// <copyright file="AddInfromationService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddInfromation
{
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.Information.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;

    public class AddInfromationService : IAddInformationService
    {
        private readonly ApplicationDbContext db;

        public AddInfromationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddInformation(AddInformationInputModel model)
        {
            this.db.Information.Add(new Information
            {
                Description = model.SanitizedDescription,
            });
            await this.db.SaveChangesAsync();
        }

        public bool HaveInformationAlready()
        {
            return this.db.Information.Count() > 0;
        }
    }
}