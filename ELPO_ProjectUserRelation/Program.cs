using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.Bussiness.Concrete;
using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Authentication for cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.Cookie.Path = "/";
        options.Cookie.Name = "cookieName";
        options.Cookie.Domain = "localhost";
    });

#region Dependency Injection

//For User
builder.Services.AddScoped<IUserDal, UserDal>();
builder.Services.AddScoped<IUserService, UserManager>();
//For Project
builder.Services.AddScoped<IProjectDal, ProjectDal>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
//For Role
builder.Services.AddScoped<IRoleDal, RoleDal>();
builder.Services.AddScoped<IRoleService, RoleManager>();
//For Category
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
//For ProjectUserRelation  
builder.Services.AddScoped<IProjectUserRelationDal, ProjectUserRelationDal>();
builder.Services.AddScoped<IProjectUserRelationService, ProjectUserRelationManager>();

#endregion

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
app.UseAuthentication();//Bunu yapmadan cookie ler kaydolmuyor

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
