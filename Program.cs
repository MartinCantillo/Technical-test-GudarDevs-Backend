using System.Text;
using DataDataContext.DataContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using RepositoriesIAuthenticate.IAuthenticate;
using RepositoriesIContact.IContact;

using ServicesSAuthenticate.SAuthenticate;
using ServicesSContact.SContact;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthenticate, SAuthenticate>();
builder.Services.AddScoped<IContact, SContact>();

//config of jwt 

builder.Configuration.AddJsonFile("appsettings.json");
string? secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretkey ?? "");
builder.Services.AddAuthentication(config =>
{

    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{

    config.RequireHttpsMetadata = false;

    config.SaveToken = true;

    config.TokenValidationParameters = new TokenValidationParameters
    {

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),

        ValidateIssuer = true,
        ValidIssuer = "backend",

        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    }
;
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config database 
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL("server=localhost;port=3306;database=bdtest;user=root");
});
//Config cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NewPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
