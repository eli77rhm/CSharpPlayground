using System.Diagnostics;
using MiddlewarePlayground.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<HeaderCheckMiddleware>();
app.UseMiddleware<HideSensitiveInformationMiddleware>();
app.UseStaticFiles();

app.MapGet("/GetTrainDocument", () =>
    {   
        var document = new CustomerDocument("Alice Johnson", 28, "456 Oak St, Sometown, USA", "Y9876543");
        Console.WriteLine("GetTrainDocument endpoint processing request.");
        return document;
    })
    .WithName("GetTrainDocument")
    .WithOpenApi();

app.Run();

record CustomerDocument(string Name, int Age, string Address, string PassportNumber)
{
    public int Age { get; set; } = Age;
    public string Name { get; set; } = Name;
    public string Address { get; set; } = Address;
    public string PassportNumber { get; set; } = PassportNumber;
}