using new_testprojectADO.Services;

var builder = WebApplication.CreateBuilder(args);

// IMPORTANT FOR DOCKER
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EmployeeService>();

// ======================
// CORS
// ======================

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

// ENABLE SWAGGER ALWAYS
app.UseSwagger();

app.UseSwaggerUI();

// IMPORTANT test
app.UseCors("AllowAngular");

// DISABLE HTTPS REDIRECTION FOR DOCKER
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();