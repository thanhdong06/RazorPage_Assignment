using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAuthenticateUser,AuthenticateUser>();
builder.Services.AddSingleton<IAccountRepo, AccountRepo>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
