// <copyright file="EditPersonService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.EditPerson
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.ViewModels;
    using KiipPazardzhik.Data;

    using Microsoft.EntityFrameworkCore;

    public class EditPersonService : IEditPersonService
    {
        private readonly ApplicationDbContext db;

        public EditPersonService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task EditPerson(EditPersonInputModel model)
        {
            var person = await this.db.People.FirstOrDefaultAsync(x => x.Id == model.Id);
            person.FirstName = model.FirstName;
            person.MiddleName = model.MiddleName;
            person.LastName = model.LastName;
            person.Email = model.Email;
            person.RegisterNumber = model.RegisterNumber;
            person.IsActive = model.IsActive;
            person.IsFrozen = model.IsFrozen;
            person.LegalCapacity = model.LegalCapacity;
            person.Phone = model.Phone;
            person.Section = model.Section;

            this.db.People.Update(person);
            await this.db.SaveChangesAsync();
        }

        public ICollection<EditPersonViewModel> GetAllPeople()
        {
            var allPeople = this.db.People.ToList();
            var result = new List<EditPersonViewModel>();

            foreach (var person in allPeople)
            {
                result.Add(new EditPersonViewModel
                {
                    Id = person.Id,
                    DisplayName = $"{person.RegisterNumber} - {person.FirstName} {person.MiddleName} {person.LastName}",
                });
            }

            return result;
        }

        public ICollection<string> GetAllSections()
        {
            return this.db.People.Select(x => x.Section).Distinct().ToList();
        }

        public async Task<GetPersonDataViewModel> GetPersonById(string personId)
        {
            var person = await this.db.People.FirstOrDefaultAsync(x => x.Id == personId);
            return new GetPersonDataViewModel
            {
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                LastName = person.LastName,
                Email = person.Email,
                LegalCapacity = person.LegalCapacity,
                Phone = person.Phone,
                RegisterNumber = person.RegisterNumber,
                IsActive = person.IsActive ? "True" : "False",
                IsFrozen = person.IsFrozen ? "True" : "False",
                Section = person.Section,
            };
        }
    }
}