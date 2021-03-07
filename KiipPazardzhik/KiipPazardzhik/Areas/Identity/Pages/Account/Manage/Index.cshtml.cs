// <copyright file="Index.cshtml.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Identity.Pages.Account.Manage
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models.Users;
    using KiipPazardzhik.ViewModels.User.ViewModels;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext db;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }

        [Display(Name = "Потребителско име")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public EditUserProfileViewModel Input { get; set; }

        private async Task LoadAsync(ApplicationUser user)
        {
            var currentUser = await this.db.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            this.Username = currentUser.UserName;

            this.Input = new EditUserProfileViewModel
            {
                PhoneNumber = currentUser.PhoneNumber,
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                MiddleName = currentUser.MiddleName,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            user.PhoneNumber = this.Input.PhoneNumber;
            user.FirstName = this.Input.FirstName;
            user.MiddleName = this.Input.MiddleName;
            user.LastName = this.Input.LastName;
            this.db.Users.Update(user);
            await this.db.SaveChangesAsync();

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Профилът Ви беше обновен успешно.";
            return this.RedirectToPage();
        }
    }
}