using AgroFile.CrossCutting.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddValidators();
builder.Services.AddIdentityUser();
builder.Services.AddDbContext(builder.Configuration);

builder.Services.AddCors(); 

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
    });
}

app.UseCors(c => 
{
    c.AllowAnyHeader(); 
    c.AllowAnyMethod(); 
    c.AllowAnyOrigin(); 
}); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
