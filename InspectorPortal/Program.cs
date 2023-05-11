//EntityFramework kullanýmý için gerekli configler burada yapýlmalýdýr. 
// DbContext extensiný eklendikten sonra DbContextOptionBuilder metodu bir parametreye atýlarak ConectionStringimiz yazýlýr. ConnectionString appsettings.json dosyasýnda tutulur. 
//AddCors ile cors policy için gerekli configurasyonlar yapýlýr. Fraklý originlerden istek atýlmasýna izin verilmiþ oluruz. Geliþtirme aþamasýnda yapýlacak bir þey olup daha sonra kaldýrýlmalýdýr??? 
using InspectorPortal.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InspectorPortalDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options => options.AddPolicy("all", pb => { pb.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();}));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>

        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hava ne kadar guzel!")),
            ClockSkew = TimeSpan.Zero,
        });
builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("all");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();



