using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Areas.Administration.ViewModels.EditPerson.ViewModels
{
    public class GetPersonDataViewModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string RegisterNumber { get; set; }

        public string Section { get; set; }

        public string LegalCapacity { get; set; }

        public string IsFrozen { get; set; }

        public string IsActive { get; set; }
    }
}