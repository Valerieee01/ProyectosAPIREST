var builder = WebApplication.CreateBuilder(args);

// Agregar servicios necesarios
builder.Services.AddControllers();           
builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerGen();            


var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
                
app.UseHttpsRedirection(); 
app.MapControllers(); 


app.Run();
                                                        