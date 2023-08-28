

using Microsoft.EntityFrameworkCore;
using Villa_VillaAPI;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Repository;
using Villa_VillaAPI.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo
//	.File("log/villaLogs.txt",rollingInterval:RollingInterval.Day).CreateLogger();


builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
	option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddScoped<IVillaRepo, VillaRepo>();
builder.Services.AddScoped<IVillaNumberRepo, VillaNumberRepo>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers(option => {
	//option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
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
