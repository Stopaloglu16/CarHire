using Application;
using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Queries;
using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.Common.Interfaces;
using Application.Repositories;
using CarHire.Services.Branchs;
using Domain.Common;
using Infrastructure.Data;
using Infrastructure.Data.EfCore;
using Infrastructure.Repositories.AddressRepos;
using Infrastructure.Repositories.BranchRepos;
using Infrastructure.Repositories.CarHireRepos;
using Infrastructure.Repositories.CarRepos;
using Infrastructure.Repositories.UserAuth;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPI.Model;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplication();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(connectionString));

builder.Services.AddDbContext<WebIdentityContext>(options =>
                 options.UseSqlServer(connectionString));



builder.Services.AddMediatR(typeof(CreateCarBrandCommand).Assembly);
builder.Services.AddMediatR(typeof(CreateCarHireCommand).Assembly);
builder.Services.AddMediatR(typeof(GetCarBrandsQuery).Assembly);


builder.Services.AddScoped(typeof(IApplicationDbContext), typeof(ApplicationDbContext));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WebIdentityContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();


builder.Services.AddScoped<IBranchService, BranchService>();

builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarHireRepository, CarHireRepository>();



// Add services to the container.
builder.Services.AddControllers();



// Add JWT token logic
{
    var services = builder.Services;

    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

    services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));
}



var jwtSettings = new JWTSettings();
builder.Configuration.Bind(nameof(JWTSettings), jwtSettings);


// Add JWT configuration
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.SecretKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});





var securityScheme = new OpenApiSecurityScheme()
{
    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    Reference = new OpenApiReference
    {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
    }
};



var securityReq = new OpenApiSecurityRequirement
{
    { securityScheme, new[] { "Bearer" } }
};


var contact = new OpenApiContact()
{
    Name = "Sertac Topaloglu",
    Email = "sertac.topaloglu@hotmail.co.uk",
    Url = new Uri("https://sites.google.com/site/sertactopaloglu/home")
};



var info = new OpenApiInfo()
{
    Version = "v1",
    Title = "Car hire API",
    Description = "JWT Authentication in Minimal API",
    TermsOfService = new Uri("https://sites.google.com/site/sertactopaloglu/home"),
    Contact = contact
};

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", info);
    o.AddSecurityDefinition("Bearer", securityScheme);
    o.AddSecurityRequirement(securityReq);
});





builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
