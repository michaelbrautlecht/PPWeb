using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PPWebApplication.Components;
using PPWebApplication.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<PPWebApplication.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PPWebConnection")));

builder.Services.AddIdentity<PPAppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

/*
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<AppDbContext>();
*/

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
