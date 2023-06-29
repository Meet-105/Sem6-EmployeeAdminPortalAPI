using EmployeeAdminPortalAPI.DataModels;
using EmployeeAdminPortalAPI.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (b) =>
    {
        b.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});

builder.Services.AddControllers(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeAdminContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeAdminPortalDb")));
builder.Services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}
app.UseCors("angularApplication");
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
