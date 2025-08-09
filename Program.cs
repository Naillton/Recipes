using Recipes.Services;
using Recipes.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:80");
builder.Services.AddControllers();
builder.Services.AddSingleton<IRecipesInterface, RecipesModelService>();
builder.Services.AddSingleton<IRecipesUserInterface, RecipesUserService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();