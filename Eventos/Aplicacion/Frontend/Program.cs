using System.Collections.Immutable;
using System.Transactions;
using System.Net;
using Persistencia;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<Persistencia.AppContext>();
builder.Services.AddScoped<IRPatrocinador,RPatrocinador>();
builder.Services.AddScoped<IRMunicipio,RMunicipio>();
builder.Services.AddScoped<IRArbitro,RArbitro>();
builder.Services.AddScoped<IRUnidadDeportiva,RUnidadDeportiva>();
builder.Services.AddScoped<IRColegio,RColegio>();
builder.Services.AddScoped<IRTorneo,RTorneo>();
builder.Services.AddScoped<IREquipo,REquipo>();
builder.Services.AddScoped<IREntrenador,REntrenador>();
builder.Services.AddScoped<IRDeportista,RDeportista>();
builder.Services.AddScoped<IREscenario,REscenario>();
builder.Services.AddScoped<IRTorneoEquipo,RTorneoEquipo>();
builder.Services.AddScoped<IRLogin,RLogin>();






// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
