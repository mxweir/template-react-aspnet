var builder = WebApplication.CreateBuilder(args);

// Füge Services hinzu, die von der App verwendet werden (z.B. Controllers)
builder.Services.AddControllers();

var app = builder.Build();

// Entwicklermodus: Verwende detaillierte Fehlerseiten
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Nutze HTTPS-Umleitung
app.UseHttpsRedirection();

// Routing für API und Controller
app.UseRouting();

// Authentifizierung und Autorisierung (falls benötigt)
app.UseAuthorization();

// Mapped die Controller (API-Endpunkte)
app.MapControllers();

// Konfiguration für das Servieren der React-Anwendung (ClientApp)
app.UseSpa(spa =>
{
    // Gibt den Pfad zu deinem React-Projekt an
    spa.Options.SourcePath = "ClientApp";

    // Falls im Entwicklungsmodus, Proxy für den React Dev Server
    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
    }
});

// Startet die App
app.Run();
