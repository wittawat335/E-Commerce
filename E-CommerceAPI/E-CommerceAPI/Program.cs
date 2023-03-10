using E_CommerceAPI.Common;
using E_CommerceAPI.DALRepository;
using E_CommerceAPI.Entities;
using E_CommerceAPI.Services.Contract;
using E_CommerceAPI.Services.Implementation;
using E_CommerceAPI.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(Constants.AppSettings.ConnectionStringSql);
var test = builder.Configuration.GetValue<string>(Constants.AppSettings.ConnectionStringSql);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(Constants.AppSettings.Client_URL).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                      });
});
//Add JWT AddAuthentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "localhost",
        ValidAudience = "localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.AppSettings.JWT_Secret)),
        ClockSkew = TimeSpan.Zero
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Dal
builder.Services.AddSingleton<IDataAccess, DataAccess>();
// Add Service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//DBContext
builder.Services.AddDbContext<EcommerceContext>(options =>
{
    options.UseSqlServer(test);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
