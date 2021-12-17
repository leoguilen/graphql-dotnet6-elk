var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfraData()
    .AddMediatR(Assembly.GetExecutingAssembly())
    .AddScoped<ISchema, QuerySchema>(services => new QuerySchema(new SelfActivatingServiceProvider(services)))
    .AddGraphQL(options => options.EnableMetrics = true)
    .AddSystemTextJson();

var app = builder.Build();

// Indicated
//if (app.Environment.IsDevelopment())
//{
//    app.UseGraphQLAltair();
//}

app.UseHsts();
app.UseHttpsRedirection();

app.UseGraphQL<ISchema>();
app.UseGraphQLAltair();

await app.RunAsync();
