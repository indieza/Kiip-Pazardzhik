// <copyright file="RegisterService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Register
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Data;
    using KiipPazardzhik.ViewModels.Register.ViewModels;

    public class RegisterService : IRegisterService
    {
        private readonly ApplicationDbContext db;

        public RegisterService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<RegisterViewModel> GetAllSections()
        {
            var allSections = this.db.People.Select(x => x.Section).Distinct().OrderBy(x => x).ToList();
            var result = new List<RegisterViewModel>();

            foreach (var item in allSections)
            {
                result.Add(new RegisterViewModel
                {
                    Name = item,
                });
            }

            return result;
        }
    }
}