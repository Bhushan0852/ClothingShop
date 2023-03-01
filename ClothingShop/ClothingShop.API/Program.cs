using ClothingShop.API.Data;
using ClothingShop.API.EFRepository.Category;
using ClothingShop.API.IEFRepository.Category;
using ClothingShop.API.Repository.IEFRepository.Product;
using ClothingShop.API.Repository.IEFRepository.User;
using ClothingShop.API.Repository.Repository.Product;
using ClothingShop.API.Repository.Repository.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClothingShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClothingShop_Demo2"));
});
builder.Services.AddScoped<IEFUserRepository, EFUserRepository>();
builder.Services.AddScoped<IEFProductRepository, EFProductRepository>();
builder.Services.AddScoped<IEFCategoryRepository, EFCategoryRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = builder.Configuration["Jwt:Issuer"],
                  ValidAudience = builder.Configuration["Jwt:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
              };
          });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
