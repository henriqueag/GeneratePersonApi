var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting();

builder.Services.AddMvc().AddClasslibPart();

builder.Services.AddAuthorization();

builder.Services.RegisterModules(builder.Configuration);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DocumentGeneratorApp.Api",
        Description = "Api que disponibiliza funcionalidades de consulta e validação de documentos",
        Contact = new OpenApiContact
        {
            Name = "Henrique Aguiar",
            Email = "henriquesantos.ag2@gmail.com",
            Url = new Uri("https://github.com/henriqueag")
        },
        Version = "v1"
    });

    var xmlFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml");

    foreach (var filename in xmlFiles)
    {
        options.IncludeXmlComments(filename);
    }
});

// Cors
builder.Services.AddCors(cors =>
{
    cors.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});

// Serilog
builder.Logging.ClearProviders();
builder.Host.UseSerilog((builder, config) =>
{
    string logPath = $"{AppDomain.CurrentDomain.BaseDirectory}/logs/document-generator.txt";

    config.MinimumLevel.Verbose()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithEnvironmentName()
        .Enrich.WithMachineName()
        .Enrich.WithProperty("ApplicationName", "Document Generator")
        .Enrich.WithProperty("ApplicationVersion", "1.0.0")
        .WriteTo.Console()
        .WriteTo.File(logPath, rollingInterval: RollingInterval.Day);
});

// Configurações
var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API interna");
    options.DocExpansion(DocExpansion.List);
});

app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();