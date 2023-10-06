var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    // Service dependency instances database
        builder.Services.AddScoped< DBConnection >();

    // Service dependency instances services
        builder.Services.AddScoped< EmailServiceImpl >();
        builder.Services.AddScoped< IEnderecoService, EnderecoServiceImpl >();

    // Service dependency instances repository
        builder.Services.AddScoped< IEnderecoRepository, EnderecoRepositoryImpl >();




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
