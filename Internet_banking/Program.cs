using Internet_banking.Infrastructure.Persistence;
using Internet_banking.Middlewares;
using Internet_banking.Core.Application;
using Microsoft.AspNetCore.Identity;
using Internet_banking.Infrastucture.Identity.Entities;
using Internet_banking.Infrastucture.Identity.Seeds;
using Internet_banking.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ValidateUserSession, ValidateUserSession>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    using (var scope = app.Services.CreateScope())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        var services = scope.ServiceProvider;

        try
        {
            var usermanager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var rolemanager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await DefaultRoles.SeedAsync(usermanager, rolemanager);
            await DefaultBasicUser.SeedAsync(usermanager, rolemanager);
            await DefaultSuperAdminUser.SeedAsync(usermanager, rolemanager);

        }
        catch (Exception ex) { }
    }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();
