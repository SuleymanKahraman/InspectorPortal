//EntityFramework kullan�m� i�in gerekli configler burada yap�lmal�d�r. 
// DbContext extensin� eklendikten sonra DbContextOptionBuilder metodu bir parametreye at�larak ConectionStringimiz yaz�l�r. ConnectionString appsettings.json dosyas�nda tutulur. 
//AddCors ile cors policy i�in gerekli configurasyonlar yap�l�r. Frakl� originlerden istek at�lmas�na izin verilmi� oluruz. Geli�tirme a�amas�nda yap�lacak bir �ey olup daha sonra kald�r�lmal�d�r??? 
using InspectorPortal.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InspectorPortalDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options => options.AddPolicy("all", pb => { pb.AllowAnyOrigin().AllowAnyHeader(); }));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("all");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



