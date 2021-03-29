// <copyright file="DeleteRegionalCollegeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeleteRegionalCollege
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeleteRegionalCollege.ViewModels;
    using KiipPazardzhik.Data;

    using Microsoft.EntityFrameworkCore;

    public class DeleteRegionalCollegeService : IDeleteRegionalCollegeService
    {
        private readonly ApplicationDbContext db;

        public DeleteRegionalCollegeService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task DeleteRegionalCollege(DeleteRegionalCollegeInputModel model)
        {
            var targetGollege = await this.db.RegionalColleges.FirstOrDefaultAsync(x => x.Id == model.Id);
            this.db.RegionalColleges.Remove(targetGollege);
            await this.db.SaveChangesAsync();
        }

        public ICollection<DeleteRegionalCollegeViewModel> GetAllGolleges()
        {
            var allColleges = this.db.RegionalColleges.ToList();
            var result = new List<DeleteRegionalCollegeViewModel>();

            foreach (var college in allColleges)
            {
                result.Add(new DeleteRegionalCollegeViewModel
                {
                    Id = college.Id,
                    Name = college.DisplayName,
                });
            }

            return result;
        }
    }
}