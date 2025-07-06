var builder = WebApplication.CreateBuilder(args);

/* ---------------- CORS */
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll",
        p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

/* ---------------- Typed HttpClient servisleri */
builder.Services.AddHttpClient<AIModelService>();   // hâlâ kullandýðýn eski servis
builder.Services.AddHttpClient<GlocomService>();    // glokom için yeni servis

/* ---------------- MVC / Swagger */
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* ---------------- Build & Middleware */
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
