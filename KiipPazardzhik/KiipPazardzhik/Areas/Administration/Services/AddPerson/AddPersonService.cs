// <copyright file="AddPersonService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddPerson
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;

    public class AddPersonService : IAddPersonService
    {
        private readonly ApplicationDbContext db;

        public AddPersonService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddPerson(AddPersonInputModel model)
        {
            this.db.People.Add(new Person
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                LegalCapacity = model.LegalCapacity,
                Phone = model.Phone,
                RegisterNumber = model.RegisterNumber,
                Section = model.Section,
                IsActive = model.IsActive,
                IsFrozen = model.IsFrozen,
                TechnicalControl = model.TechnicalControl,
                Position = model.Position,
            });

            await this.db.SaveChangesAsync();
        }

        public ICollection<string> GetAllPosition()
        {
            return this.db.People.Select(x => x.Position).Distinct().ToList();
        }

        public ICollection<string> GetAllSections()
        {
            return this.db.People.Select(x => x.Section).Distinct().ToList();
        }

        public ICollection<string> GetAllTechnicalControls()
        {
            return this.db.People.Select(x => x.TechnicalControl).Distinct().ToList();
        }
    }
}