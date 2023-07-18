using CMS.Persistanse.EF;
using CMS.Persistanse.EF.Blocks;
using CMS.Persistanse.EF.Complexs;
using CMS.Persistanse.EF.ComplexUsageType;
using CMS.Persistanse.EF.Units;
using CMS.Persistanse.EF.UsageTypes;
using CMS.Services.Blocks;
using CMS.Services.Blocks.Contracts;
using CMS.Services.Complexs;
using CMS.Services.Complexs.Contract;
using CMS.Services.ComplexUsageTypes.Contracts;
using CMS.Services.Contracts;
using CMS.Services.Units.Contracts;
using CMS.Services.UsageType.Contract;
using CMS.Services.UsageTypes;
using ComplexManagment.Services.Blocks.Contracts;
using ComplexManagment.Services.Units;
using ComplexManagment.Services.Units.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EFDataContext>(_ =>
    _.UseSqlServer("Server=.;Database=CMSDATABASEEEEEEEEEEEEEEE12;Trusted_Connection=True;"));

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<ComplexService, ComplexAppService>();
builder.Services.AddScoped<ComplexRepasitory, EFComplexRepasitory>();
builder.Services.AddScoped<ComplexUsageTypeRepository, EFComplexUsageTypeRepository>();
builder.Services.AddScoped<ComplexUsageTypeService, ComplexUsageTypeAppService>();
builder.Services.AddScoped<UsageTypeRepository, EFUsageTypeRepository>();
builder.Services.AddScoped<UsageTypeService, UsageTypeAppService>();
builder.Services.AddScoped<BlockRepository, EfBlockRepository>();
builder.Services.AddScoped<BlockService, BlockAppService>();
builder.Services.AddScoped<UnitService, UnitAppService>();
builder.Services.AddScoped<UnitRepository, EFUnitRepository>();



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
