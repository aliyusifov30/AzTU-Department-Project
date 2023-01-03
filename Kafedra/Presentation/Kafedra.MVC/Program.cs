

using Kafedra.Domain.Entities;

using Kafedra.Application;


using Kafedra.Domain.Entities;
using Kafedra.Application;

using Kafedra.Domain.Enums;
using Kafedra.Domain.Identities;
using Kafedra.Infrastructure;
using Kafedra.Persistence;
using Kafedra.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<KafedraContext>().AddDefaultTokenProviders()
//                .AddTokenProvider<EmailConfirmationTokenProvider<AppUser>>("emailconfirmation"); 

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddStorageType(StorageType.ILocalStorage);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
        pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();