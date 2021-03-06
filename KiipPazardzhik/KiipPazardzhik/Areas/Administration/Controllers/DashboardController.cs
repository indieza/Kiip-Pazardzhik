// <copyright file="DashboardController.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Areas.Administration.Services.Dashboard;
    using KiipPazardzhik.Areas.Administration.ViewModels.Dashboard.InputModels;
    using KiipPazardzhik.Areas.Administration.ViewModels.Dashboard.ViewModels;
    using KiipPazardzhik.Constraints;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel
            {
                AllUsers = this.dashboardService.GetAllUsers(),
                AllAdminsCount = await this.dashboardService.GetAllAdminsCount(),
                AllUsersCount = await this.dashboardService.GetAllUsersCount(),
                AllAdminsNames = await this.dashboardService.GetAllAdminsNames(),
                AllNotAdminsNames = await this.dashboardService.GetAllNotAdminsNames(),
            };

            var model = new DashboardBaseModel
            {
                DashboardViewModel = viewModel,
                AddRemoveAdminInputModel = new AddRemoveAdminInputModel(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdministrator(DashboardBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.dashboardService.RemoveAdministrator(model.AddRemoveAdminInputModel.Username);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyRemoveAdministrator,
                    model.AddRemoveAdminInputModel.Username.ToUpper(),
                    GlobalConstants.AdministratorRole.ToUpper());
                return this.RedirectToAction("Index", "Dashboard");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "Dashboard", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAdministrator(DashboardBaseModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.dashboardService.AddAdministrator(model.AddRemoveAdminInputModel.Username);
                this.TempData["Success"] = string.Format(
                    MessageConstants.SuccessfullyAddAdministrator,
                    model.AddRemoveAdminInputModel.Username.ToUpper(),
                    GlobalConstants.AdministratorRole.ToUpper());
                return this.RedirectToAction("Index", "Dashboard");
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
                return this.RedirectToAction("Index", "Dashboard", model);
            }
        }

        [Route("/Administration/Dashboard/ApproveUser/{id?}")]
        public async Task<IActionResult> ApproveUser(string id)
        {
            if (id != string.Empty)
            {
                await this.dashboardService.ApproveUser(id);
                this.TempData["Success"] = MessageConstants.SuccessfullyApprovedEser;
            }
            else
            {
                this.TempData["Error"] = MessageConstants.InvalidInputModel;
            }

            return this.RedirectToAction("Index", "Dashboard");
        }
    }
}