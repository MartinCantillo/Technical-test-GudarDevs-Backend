using RepositoriesIAdditionalField.IAdditionalField;
using RepositoriesIAuthenticate.IAuthenticate;
using RepositoriesIContact.IContact;
using RepositoriesIContactType.IContactType;
using ServicesSAdditionalField.SAdditionalField;
using ServicesSAuthenticate.SAuthenticate;
using ServicesSContact.SContact;
using ServicesSContactType.SContactType;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthenticate, SAuthenticate>();
builder.Services.AddScoped<IAdditionalField, SAdditionalField>();
builder.Services.AddScoped<IContact, SContact>();
builder.Services.AddScoped<IContactType, SContactType>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
