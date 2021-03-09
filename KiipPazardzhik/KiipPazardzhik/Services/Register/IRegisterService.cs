using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using KiipPazardzhik.ViewModels.Register.ViewModels;
using KiipPazardzhik.ViewModels.Website.ViewModels;

namespace KiipPazardzhik.Services.Register
{
    public interface IRegisterService
    {
        ICollection<RegisterViewModel> GetAllSections();
        ICollection<PersonViewModel> GetAllPeopleInSection(string sectionName);
    }
}