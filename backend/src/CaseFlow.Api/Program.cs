using CaseFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // register Controller-based Api
builder.Services.AddCaseFlowPersistence(builder.Configuration); // register CaseFlowDbContext and configure database connection
builder.Services.AddOpenApi(); // register Open Api service

var app = builder.Build(); // build web app

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // expose OpenApi in dev environment only
}

app.MapControllers(); // map controller endpoints

app.Run();  // start the backend server and listen for requests
