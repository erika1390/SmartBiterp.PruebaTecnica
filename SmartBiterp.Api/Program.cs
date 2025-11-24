using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using SmartBiterp.Application.Interfaces.Expense;
using SmartBiterp.Application.Interfaces.Security;
using SmartBiterp.Application.Mapping;
using SmartBiterp.Application.Services.Expense;
using SmartBiterp.Application.Services.Security;
using SmartBiterp.Domain.Interfaces;
using SmartBiterp.Domain.Interfaces.Expense;
using SmartBiterp.Domain.Interfaces.Security;
using SmartBiterp.Domain.Interfaces.System;

using SmartBiterp.Infrastructure.Persistence.Context;
using SmartBiterp.Infrastructure.Repositories.Expense;
using SmartBiterp.Infrastructure.Repositories.Security;
using SmartBiterp.Infrastructure.Repositories.System;
using SmartBiterp.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartBiterp API",
        Version = "v1"
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ExpenseMappingProfile>();
    cfg.AddProfile<SecurityMappingProfile>();
    cfg.AddProfile<SystemMappingProfile>();
});

// Services
builder.Services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
builder.Services.AddScoped<IMoneyFundService, MoneyFundService>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IDepositService, DepositService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddScoped<IMenuRoleService, MenuRoleService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();

// Expense Repositories
builder.Services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
builder.Services.AddScoped<IMoneyFundRepository, MoneyFundRepository>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IDepositRepository, DepositRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// Security Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuRoleRepository, MenuRoleRepository>();

// System Repositories
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();

// UoW
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();


// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();