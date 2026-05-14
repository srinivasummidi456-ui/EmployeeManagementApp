using new_testprojectADO.Services;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// RUN API INSIDE DOCKER
// ===============================

builder.WebHost.UseUrls("http://0.0.0.0:8080");

// ===============================
// SERVICES
// ===============================

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EmployeeService>();

// ===============================
// CORS CONFIGURATION
// ===============================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// ===============================
// MIDDLEWARE PIPELINE
// ===============================

// Swagger
app.UseSwagger();

app.UseSwaggerUI();

// CORS
app.UseCors("AllowAngular");

// Authorization
app.UseAuthorization();

// Controllers
app.MapControllers();

// ===============================
// START APPLICATION
// ===============================

app.Run();