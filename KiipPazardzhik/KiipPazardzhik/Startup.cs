// <copyright file="Startup.cs" company="Kiip Pazardzhik">
// Copyright (c) Kiip Pazardzhik. All rights reserved.
// </copyright>

namespace KiipPazardzhik
{
    using System;

    using CloudinaryDotNet;

    using KiipPazardzhik.Areas.Administration.Services.AddDesignOffice;
    using KiipPazardzhik.Areas.Administration.Services.AddDocument;
    using KiipPazardzhik.Areas.Administration.Services.AddInfromation;
    using KiipPazardzhik.Areas.Administration.Services.AddNews;
    using KiipPazardzhik.Areas.Administration.Services.AddPeople;
    using KiipPazardzhik.Areas.Administration.Services.AddPerson;
    using KiipPazardzhik.Areas.Administration.Services.AddRegionalCollege;
    using KiipPazardzhik.Areas.Administration.Services.Dashboard;
    using KiipPazardzhik.Areas.Administration.Services.DeleteDocument;
    using KiipPazardzhik.Areas.Administration.Services.DeleteNews;
    using KiipPazardzhik.Areas.Administration.Services.DeletePerson;
    using KiipPazardzhik.Areas.Administration.Services.DeleteRegionalCollege;
    using KiipPazardzhik.Areas.Administration.Services.EditDesignOffice;
    using KiipPazardzhik.Areas.Administration.Services.EditInformation;
    using KiipPazardzhik.Areas.Administration.Services.EditNews;
    using KiipPazardzhik.Areas.Administration.Services.EditPerson;
    using KiipPazardzhik.Data;
    using KiipPazardzhik.Models.Users;
    using KiipPazardzhik.Services.Cloud;
    using KiipPazardzhik.Services.Contact;
    using KiipPazardzhik.Services.DesignOffices;
    using KiipPazardzhik.Services.Documents;
    using KiipPazardzhik.Services.Home;
    using KiipPazardzhik.Services.Information;
    using KiipPazardzhik.Services.News;
    using KiipPazardzhik.Services.Register;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using OfficeOpenXml;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders().AddDefaultUI();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Identity/Account/Login";
                options.SlidingExpiration = true;
            });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });

            // Configuration for update cookies when user is added in Role!!!
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.FromMinutes(0);
            });

            // Cloudinary Authentication
            var cloudinaryAccount = new Account(
                this.Configuration["Cloudinary:CloudName"],
                this.Configuration["Cloudinary:ApiKey"],
                this.Configuration["Cloudinary:ApiSecret"]);
            var cloudinary = new Cloudinary(cloudinaryAccount);
            services.AddSingleton(cloudinary);

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IRegisterService, RegisterService>();
            services.AddTransient<IDocumentsService, DocumentsService>();
            services.AddTransient<IInformationService, InformationService>();
            services.AddTransient<IDesignOfficesService, DesignOfficesService>();
            services.AddTransient<IContactService, ContactService>();

            // Register Administration Services
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IAddPersonService, AddPersonService>();
            services.AddTransient<IDeletePersonService, DeletePersonService>();
            services.AddTransient<IAddNewsService, AddNewsService>();
            services.AddTransient<IDeleteNewsService, DeleteNewsService>();
            services.AddTransient<IAddDocumentService, AddDocumentService>();
            services.AddTransient<IEditPersonService, EditPersonService>();
            services.AddTransient<IDeleteDocumentService, DeleteDocumentService>();
            services.AddTransient<IEditNewsService, EditNewsService>();
            services.AddTransient<IAddPeopleService, AddPeopleService>();
            services.AddTransient<IAddRegionalCollegeService, AddRegionalCollegeService>();
            services.AddTransient<IDeleteRegionalCollegeService, DeleteRegionalCollegeService>();
            services.AddTransient<IAddInformationService, AddInfromationService>();
            services.AddTransient<IEditInformationService, EditInformationService>();
            services.AddTransient<IAddDesignOfficeService, AddDesignOfficeService>();
            services.AddTransient<IEditDesignOfficeService, EditDesignOfficeService>();

            // Register OfficeOpenXml License
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}