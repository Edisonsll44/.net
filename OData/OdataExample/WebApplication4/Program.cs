using Inpsercom.Core.Generico.ResolucionDependencias;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
{
    var service = builder.Services;
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    IoCRegisterDataContext.AddRegisterContext(service, connectionString);
    IoCRegister.AddRegistration(service);
    service.AddEndpointsApiExplorer();
    service.AddCors();
    service.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    service.AddSwaggerGen();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
