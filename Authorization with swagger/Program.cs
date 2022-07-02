using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(option => {

    // edit on swagger form 
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Authorization with swagger",
        Contact = new OpenApiContact
        {
            Name = "Mohamad Makkawi",
            Email = "0.0.1Makkawi@gmail.com",
            Url = new Uri("https://github.com/Makkawi011")
        }
    });

    //Authorization for all requests

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter your JWT key",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    //Authorization for specific requests
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },

                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
        
    });

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
