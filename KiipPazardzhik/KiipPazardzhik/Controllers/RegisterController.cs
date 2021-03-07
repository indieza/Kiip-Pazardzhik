// <copyright file="RegisterController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RegisterController : Controller
    {
        public RegisterController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}