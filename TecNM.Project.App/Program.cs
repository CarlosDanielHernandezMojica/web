using TecNM.Project.App.Repositories;
using TecNM.Project.App.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICategoryRepository, InMemoryCategoryRepository>();
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<INoteRespository, InMemoryNoteRepository>();
builder.Services.AddSingleton<IResourceRepository, InMemoryResourceRepository>();
builder.Services.AddSingleton<ITestRepository, InMemoryTestRepository>();
builder.Services.AddSingleton<ITestContentRepository, InMemoryTestContentRepository>();
builder.Services.AddSingleton<ITestGradeRepository, InMemoryTestGradeRepository>();



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

