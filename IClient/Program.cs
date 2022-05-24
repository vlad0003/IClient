using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IClient.Areas.Identity;
using IClient.Data;
using IClient.PluginsEFCore;
using IClient.UseCases;
using IClient.UseCases.PluginsInterfaces;
using IClient.UseCases.Reports;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services
    .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


builder.Services.AddDbContext<IClientContext>(options =>
{
    options.UseNpgsql(@"Server=localhost;Port=5432;User Id=postgres;Password=3119;Database=XCLient");
});

builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IInventoryTransactionRepository, InventoryTransactionRepository>();
builder.Services.AddTransient<IProductTransactionRepository, ProductTransactionRepository>();
builder.Services.AddTransient<IViewInventoryByNameUseCase, ViewInventoryByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryById, ViewInventoryById>();
builder.Services.AddTransient<IViewProductByNameUseCase, ViewProductByNameUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IViewInventoryById, ViewInventoryById>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IPurchaseInventoryUseCase, PurchaseInventoryUseCase>();
builder.Services.AddTransient<IValidateEnoughInventoriesForProducingUseCase, ValidateEnoughInventoriesForProducingUseCase>();
builder.Services.AddTransient<IProduceProductUseCase, ProduceProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<ISearchInventoryTransactionsUseCase, SearchInventoryTransactionsUseCase>();
builder.Services.AddTransient<ISearchProductTransactionUseCase, SearchProductTransactionUseCase>();


builder.Services.AddAuthentication()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "765926947883-43a25569bvee1h2dmg4ub6irpgrokq9c.apps.googleusercontent.com";
    googleOptions.ClientSecret = "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";
});

var app = builder.Build();
var scope = app.Services.CreateScope();
var IClientContext = scope.ServiceProvider.GetRequiredService<IClient.PluginsEFCore.IClientContext>();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
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

app.Run();