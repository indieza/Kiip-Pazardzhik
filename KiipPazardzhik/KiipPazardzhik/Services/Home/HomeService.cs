using KiipPazardzhik.Constraints;
using KiipPazardzhik.Data;
using KiipPazardzhik.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KiipPazardzhik.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext db;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeService(
            ApplicationDbContext db,
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task SubmitAllRoles()
        {
            var isUserRoleExist = await this.roleManager
                .FindByNameAsync(GlobalConstants.UserRole);

            var isAdminRoleExist = await this.roleManager
                .FindByNameAsync(GlobalConstants.AdministratorRole);

            if (isUserRoleExist == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = GlobalConstants.UserRole,
                });
            }

            if (isAdminRoleExist == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = GlobalConstants.AdministratorRole,
                });
            }
        }
    }
}