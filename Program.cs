using AutoMapper;
using CasaInteligente.Data.Contexts;
using CasaInteligente.Data.Repository;
using CasaInteligente.Models;
using CasaInteligente.Services;
using CasaInteligente.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
#region INICIALIZANDO O BANCO DE DADOS

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion
/*
#region Registro IserviceCollection
builder.Services.AddSingleton<ICustomLogger, MockLogger>();
#endregion
*/
#region Registro de Servicos e Repositorios

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICasaRepository, CasaRepository>();
builder.Services.AddScoped<ICasaService, CasaService>();
builder.Services.AddScoped<IDispositivoSegService, DispositivoSegService>();
builder.Services.AddScoped<IDispositivoSegRepository, DispositivoSegRepository>();
builder.Services.AddScoped<IEventoDeEmergenciaRepository, EventoDeEmergenciaRepository>();
builder.Services.AddScoped<IEventoDeEmergenciaService, EventoDeEmergenciaService>();

#endregion

#region AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration( c =>
    {
        c.AllowNullCollections = true;
        c.AllowNullDestinationValues = true;

        c.CreateMap<CasaModel, CasaCreateViewModel>();
        c.CreateMap<CasaCreateViewModel, CasaModel>();
        c.CreateMap<CasaViewModel, CasaModel>();
        c.CreateMap<CasaModel, CasaViewModel>();
        c.CreateMap<CasaModel, CasaUpdateViewModel>();
        c.CreateMap<CasaUpdateViewModel, CasaModel>();
        
        c.CreateMap<UsuarioModel, UsuarioCreateViewModel>();
        c.CreateMap<UsuarioCreateViewModel, UsuarioModel>();
        c.CreateMap<UsuarioModel, UsuarioViewModel>();
        c.CreateMap<UsuarioViewModel, UsuarioModel>();
        c.CreateMap<UsuarioUpdateViewModel, UsuarioModel>();
        c.CreateMap<UsuarioModel, UsuarioUpdateViewModel>();
        

        c.CreateMap<DispositivoSegModel, DispositivoSegViewModel>();
        c.CreateMap<DispositivoSegViewModel, DispositivoSegModel>();
        c.CreateMap<DispositivoSegModel, DispositivoSegUpdateViewModel>();
        c.CreateMap<DispositivoSegUpdateViewModel, DispositivoSegModel>();
        c.CreateMap<DispositivoSegModel, DispositivoSegCreateViewModel>();
        c.CreateMap<DispositivoSegCreateViewModel, DispositivoSegModel>();

        c.CreateMap<EventoDeEmergenciaModel, EventoDeEmergenciaViewModel>();
        c.CreateMap<EventoDeEmergenciaViewModel, EventoDeEmergenciaModel>();
        c.CreateMap<EventoDeEmergenciaModel, EventoDeEmergenciaCreateViewModel>();
        c.CreateMap<EventoDeEmergenciaCreateViewModel, EventoDeEmergenciaViewModel>();
        c.CreateMap<EventoDeEmergenciaModel, EventoDeEmergenciaUpdateViewModel>();
        c.CreateMap<EventoDeEmergenciaUpdateViewModel, EventoDeEmergenciaViewModel>();





    }
);

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

builder.Services.AddControllersWithViews();
// Add services to the container.

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