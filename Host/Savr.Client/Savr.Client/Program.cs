using MudBlazor.Services;
using Savr.Client.Components;
using Savr.Client.Services;
using Savr.Client.Services.Interafces;

var builder = WebApplication.CreateBuilder(args);
var baseAddress = builder.Configuration.GetValue<string>("WebCLientConfigs:BaseURL");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddHttpClient<IIncomeService, IncomeService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});
builder.Services.AddHttpClient<IExpenseService, ExpenseService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});
builder.Services.AddHttpClient<IDashboardService, DashboardService>(client =>
{
    client.BaseAddress = new Uri(baseAddress);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
