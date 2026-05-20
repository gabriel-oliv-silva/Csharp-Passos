
using Enemix.Data;
using Enemix.Repository;
using Enemix.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração para PostgreSQL (Supabase)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorCodesToAdd: null);
        }));
// 2. Injeção de Dependência (DI) - Repositories
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<ITopicoRepository, TopicoRepository>();

// 3. Injeção de Dependência (DI) - Services
builder.Services.AddScoped<IPdfParserService, PdfParserService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Garantir que o banco de dados seja criado na primeira execução (Code-First)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); // Ou EnsureCreated() para desenvolvimento inicial
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Materiais}/{action=Index}/{id?}");
app.Run();