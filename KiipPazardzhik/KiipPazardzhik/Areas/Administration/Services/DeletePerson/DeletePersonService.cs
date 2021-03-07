// <copyright file="DeletePersonService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.DeletePerson
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.DeletePerson.ViewModels;
    using KiipPazardzhik.Data;

    using Microsoft.EntityFrameworkCore;

    public class DeletePersonService : IDeletePersonService
    {
        private readonly ApplicationDbContext db;

        public DeletePersonService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task DeletePerson(DeletePersonInputModel model)
        {
            var targetPerson = await this.db.People.FirstOrDefaultAsync(x => x.Id == model.Id);
            this.db.People.Remove(targetPerson);
            await this.db.SaveChangesAsync();
        }

        public ICollection<DeletePersonViewModel> GetAllPeople()
        {
            var people = this.db.People.ToList();
            var result = new List<DeletePersonViewModel>();

            foreach (var person in people)
            {
                result.Add(new DeletePersonViewModel
                {
                    Id = person.Id,
                    DisplayField =
                    $"{person.RegisterNumber} - {person.FirstName} {person.MiddleName} {person.LastName}",
                });
            }

            return result;
        }
    }
}