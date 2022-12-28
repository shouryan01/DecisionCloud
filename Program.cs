using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WebPWrecover.Services;
using DecisionCloud.Areas.Identity;
using DecisionCloud.Data;
using Microsoft.AspNetCore.Authorization;
using DecisionCloud.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var ssConnectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(ssConnectionString));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<DecisionCloudUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<DecisionCloudUser>>();

builder.Services.AddAuthentication()
    .AddMicrosoftAccount(microsoftOptions =>
    {
        microsoftOptions.ClientId = builder.Configuration["Authentication:Microsoft:ClientId"];
        microsoftOptions.ClientSecret = builder.Configuration["Authentication:Microsoft:ClientSecret"];
    })
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });

builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

HttpClientHandler clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

// Pass the handler to httpclient(from you are calling api)
HttpClient client = new HttpClient(clientHandler);

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Initialize the database
// var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
// using (var scope = scopeFactory.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//     SeedData.Initialize(db);

// }

app.Run();
