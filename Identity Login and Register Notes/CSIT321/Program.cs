using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CSIT321.Data;
using CSIT321.Areas.Identity.Data;
using CSIT321.Models;
var builder = WebApplication.CreateBuilder(args);
var AuthenticationDBContextConnection = builder.Configuration.GetConnectionString("AuthenticationDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthenticationDBContextConnection' not found.");
var NoteDBContextConnection = builder.Configuration.GetConnectionString("NoteDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthenticationDBContextConnection' not found.");

builder.Services.AddDbContext<AuthenticationDBContext>(options => options.UseSqlServer(AuthenticationDBContextConnection));
builder.Services.AddDbContext<NoteDBContext>(options => options.UseSqlServer(NoteDBContextConnection));
// builder.Services.AddDefaultIdentity<UserAuthentication>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AuthenticationDBContext>();
// disable email configuration for a newly created account! true -> false
builder.Services.AddDefaultIdentity<UserApplication>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AuthenticationDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // FOR IDENTITY


//Configure ALL DEFAULT Validation HERE!
//Configure ALL DEFAULT Validation HERE!
//Configure ALL DEFAULT Validation HERE!
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // FOR IDENTITY
app.Run();
