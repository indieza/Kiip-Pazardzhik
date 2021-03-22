using KiipPazardzhik.Services.Contact;
using KiipPazardzhik.ViewModels.Contacts.InputModels;

using Microsoft.AspNetCore.Mvc;

namespace KiipPazardzhik.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService contactsService;

        public ContactsController(IContactService contactsService)
        {
            this.contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return this.View(new ContactsInputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.contactsService.SendEmail(model);
            this.TempData["Success"] = $"Успешно изпратихте съобщението си.";
            return this.RedirectToPage("/");
        }
    }
}