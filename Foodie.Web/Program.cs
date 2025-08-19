using Foodie.Web.Components;
using MudBlazor.Services;
using Foodie.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

// Add HttpClient
builder.Services.AddHttpClient();

// Register client services
builder.Services.AddScoped<ClientUserService>();
builder.Services.AddScoped<ClientProductService>();
builder.Services.AddScoped<ClientOrderService>();
builder.Services.AddScoped<ClientOrderItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
