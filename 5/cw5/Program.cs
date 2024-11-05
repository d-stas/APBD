using cw5.Context;
using cw5.Services.ClientsService;
using cw5.Services.ClientsService.Abstract;
using cw5.Services.TripsService;
using cw5.Services.TripsService.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MasterContext>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITripsService, TripsService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();