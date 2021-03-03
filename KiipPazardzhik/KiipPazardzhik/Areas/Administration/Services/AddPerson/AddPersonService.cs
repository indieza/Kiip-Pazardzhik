using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.InputModels;
using KiipPazardzhik.Data;
using KiipPazardzhik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Areas.Administration.Services.AddPerson
{
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
            });

            await this.db.SaveChangesAsync();
        }
    }
}