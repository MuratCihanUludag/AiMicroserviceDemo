
using AiDemi.Catalog.PresentationAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

builder.Services.AddOpenApi();

builder.Services.AddCategoryApiExtension();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
