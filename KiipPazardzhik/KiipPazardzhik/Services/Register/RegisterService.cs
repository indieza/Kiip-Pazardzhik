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
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    public class RegisterService : IRegisterService
    {
        private readonly ApplicationDbContext db;

        public RegisterService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ICollection<PersonViewModel> GetAllPeopleInSection(string sectionName)
        {
            var people = this.db.People
                .Where(x => x.Section == sectionName)
                .OrderBy(x => x.RegisterNumber)
                .ToList();
            var result = new List<PersonViewModel>();

            foreach (var person in people)
            {
                result.Add(new PersonViewModel
                {
                    Id = person.Id,
                    Email = person.Email,
                    FirstName = person.FirstName,
                    IsActive = person.IsActive,
                    IsFrozen = person.IsFrozen,
                    LastName = person.LastName,
                    LegalCapacity = person.LegalCapacity,
                    MiddleName = person.MiddleName,
                    Phone = person.Phone,
                    Position = person.Position,
                    RegisterNumber = person.RegisterNumber,
                    Section = person.Section,
                    TechnicalControl = person.TechnicalControl,
                });
            }

            return result;
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