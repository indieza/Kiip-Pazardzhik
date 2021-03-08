// <copyright file="HomeService.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik.Services.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using KiipPazardzhik.Constraints;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models.Users;
    using KiipPazardzhik.ViewModels.Website.ViewModels;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> HasAdministrator()
        {
            var isAdminRoleExist = await this.roleManager.FindByNameAsync(GlobalConstants.AdministratorRole);
            if (isAdminRoleExist == null)
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = GlobalConstants.AdministratorRole,
                });
            }

            var adminRole = await this.db.Roles
                .FirstOrDefaultAsync(x => x.Name == GlobalConstants.AdministratorRole);
            var adminsCount = await this.db.UserRoles
                .CountAsync(x => x.RoleId == adminRole.Id && x.UserId != null);

            return adminsCount != 0;
        }

        public async Task MakeYourselfAdmin(ApplicationUser currentUser)
        {
            await this.userManager.AddToRoleAsync(currentUser, GlobalConstants.AdministratorRole);
        }

        public ICollection<SingleNewsViewModel> GetTopNews(int count)
        {
            var result = new List<SingleNewsViewModel>();
            var allNews = this.db.News.OrderByDescending(x => x.CreatedOn).Take(count).ToList();

            foreach (var currentNews in allNews)
            {
                var news = new SingleNewsViewModel
                {
                    Id = currentNews.Id,
                    Description = currentNews.Description,
                    Title = currentNews.Title,
                    ShortDescription = currentNews.ShortDescription,
                    CreatedOn = currentNews.CreatedOn,
                };

                var allNewsFiles = this.db.WebsiteFiles.Where(x => x.NewsId == currentNews.Id).ToList();

                foreach (var file in allNewsFiles)
                {
                    news.Files.Add(new WebsiteFileViewModel
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Url = file.Url,
                    });
                }

                result.Add(news);
            }

            return result;
        }
    }
}