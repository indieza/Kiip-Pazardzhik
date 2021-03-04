// <copyright file="Email.cshtml.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;

    public partial class EmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly ApplicationDbContext db;

        public EmailModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.db = db;
        }

        public string Username { get; set; }

        [Display(Name = "Мейл")]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Полето е задължително")]
            [EmailAddress]
            [Display(Name = "Нов мейл")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var email = await this.userManager.GetEmailAsync(user);
            this.Email = email;

            this.Input = new InputModel
            {
                NewEmail = email,
            };

            this.IsEmailConfirmed = await this.userManager.IsEmailConfirmedAsync(user);
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

        public async Task<IActionResult> OnPostChangeEmailAsync()
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

            var email = await this.userManager.GetEmailAsync(user);
            if (this.Input.NewEmail != email)
            {
                user.Email = this.Input.NewEmail;
                this.db.Users.Update(user);
                await this.db.SaveChangesAsync();

                this.StatusMessage = "Твоят мейл е променен.";
                return this.RedirectToPage();
            }

            this.StatusMessage = "Твоят мей е непроменен.";

            return this.RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
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

            var userId = await this.userManager.GetUserIdAsync(user);
            var email = await this.userManager.GetEmailAsync(user);
            var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = this.Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: this.Request.Scheme);
            await this.emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            this.StatusMessage = "Verification email sent. Please check your email.";
            return this.RedirectToPage();
        }
    }
}