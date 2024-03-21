using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SistemBibliotecario.Data;
using SistemBibliotecario.Data.Map;
using SistemBibliotecario.Repositorio;
using SistemBibliotecario.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string chaveSecreta = "4a813e5f-5f28-4ed3-beed-a78a483f0277";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Tarefas - API", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "Jwt Autenticação",
        Description = "Entre com o JWT Bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new string[] {} }
    });
});

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
builder.Services.AddScoped<IAutorRepositorio, AutorRepositorio>();
builder.Services.AddScoped<IEditoraRepositorio, EditorarRepositorio>();
builder.Services.AddScoped<IEmprestimoRepositorio, EmprestimoRepositorio>();
builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
builder.Services.AddScoped<IAvaliacaoRepositorio, AvaliacaoRepositorio>();


builder.Services.AddDbContext<bibliotecaDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
);

/*Adicionar as configurações*/
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true, //Emissor do token,
        ValidateAudience = true, //Destinatário do Token
        ValidateLifetime = true, //Termino do Token
        ValidateIssuerSigningKey = true, //Chave de Assinatura
        ValidIssuer = "empresa",
        ValidAudience = "aplicacao",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta))
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