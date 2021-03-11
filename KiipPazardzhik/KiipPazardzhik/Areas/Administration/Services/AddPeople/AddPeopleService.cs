// <copyright file="AddPeopleService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Services.AddPeople
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.ViewModels.AddPeople.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.AddPerson.InputModels;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models;

    using OfficeOpenXml;

    public class AddPeopleService : IAddPeopleService
    {
        private readonly ApplicationDbContext db;

        public AddPeopleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task AddPeople(AddPeopleInputModel model)
        {
            using (var stream = new MemoryStream())
            {
                await model.File.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var person = new AddPersonInputModel
                        {
                            RegisterNumber = worksheet.Cells[row, 1].Value?.ToString(),
                            Position = worksheet.Cells[row, 2].Value?.ToString(),
                            FirstName = worksheet.Cells[row, 3].Value?.ToString(),
                            MiddleName = worksheet.Cells[row, 4].Value?.ToString(),
                            LastName = worksheet.Cells[row, 5].Value?.ToString(),
                            LegalCapacity = worksheet.Cells[row, 6].Value?.ToString(),
                            Section = worksheet.Cells[row, 7].Value?.ToString(),
                            TechnologistKind = worksheet.Cells[row, 8].Value?.ToString(),
                            Phone = worksheet.Cells[row, 9].Value?.ToString(),
                            Email = worksheet.Cells[row, 10].Value?.ToString(),
                            TechnicalControl = worksheet.Cells[row, 11].Value?.ToString(),
                        };

                        if (IsValid(person))
                        {
                            this.db.People.Add(new Person
                            {
                                RegisterNumber = person.RegisterNumber,
                                Position = person.Position,
                                FirstName = person.FirstName,
                                MiddleName = person.MiddleName,
                                LastName = person.LastName,
                                LegalCapacity = person.LegalCapacity,
                                Section = person.Section,
                                TechnologistKind = person.TechnologistKind,
                                Phone = person.Phone,
                                Email = person.Email,
                                TechnicalControl = person.TechnicalControl,
                            });

                            await this.db.SaveChangesAsync();
                        }
                    }
                }
            }
        }

        public MemoryStream CreateTemplate()
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Шаблон");
                workSheet.Cells[1, 1].Value = "Регистрационен номер";
                workSheet.Cells[1, 2].Value = "Позиция";
                workSheet.Cells[1, 3].Value = "Име";
                workSheet.Cells[1, 4].Value = "Презиме";
                workSheet.Cells[1, 5].Value = "Фамилия";
                workSheet.Cells[1, 6].Value = "ПП";
                workSheet.Cells[1, 7].Value = "Секция";
                workSheet.Cells[1, 8].Value = "Вид Технолог";
                workSheet.Cells[1, 9].Value = "Телефон";
                workSheet.Cells[1, 10].Value = "Мейл";
                workSheet.Cells[1, 11].Value = "Технически контрол";
                package.Save();
            }

            return stream;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}