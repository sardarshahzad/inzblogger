using blogger.Data;
using blogger.Repository;
using blogger.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<inzBloggerContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
}, ServiceLifetime.Transient);

builder.Services.AddTransient<IUserAccount, UserAccountRepository>(p => new UserAccountRepository(builder.Services.BuildServiceProvider().GetService<inzBloggerContext>()));

builder.Services.AddTransient<IUser, UserRepository>(p => new UserRepository(builder.Services.BuildServiceProvider().GetService<inzBloggerContext>()));
builder.Services.AddTransient<IPost,PostRepository>(p => new PostRepository(builder.Services.BuildServiceProvider().GetService<inzBloggerContext>()));
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
