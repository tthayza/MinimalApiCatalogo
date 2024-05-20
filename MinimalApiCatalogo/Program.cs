using MinimalApiCatalogo.ApiEndpoints;
using MinimalApiCatalogo.AppServicesExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthenticationJwt();

var app = builder.Build();

app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();

// Configure the HTTP request pipeline.
var environment = app.Environment;

app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();


