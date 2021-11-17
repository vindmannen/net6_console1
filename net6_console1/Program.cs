using Microsoft.AspNetCore.Builder;

var regions = new Dictionary<string, string>(){
                        {"Norrbotten","Luleå,Kiruna,Pajala,Haparanda,Boden,Piteå,Kalix,Överkalix,Jokkmokk"},
                        {"Västerbotten", "Umeå, Sorsele, Vilhelmina,Åsele,Dorotea"},
                        {"Jämtland", "Östersund, Ragunda"},
                        {"Västernorrland","Härnösand, Kramfors, Sollefteå, Ånge" },
                        {"Stockholm","Stockholm, Solna, Sundbyberg, Huddinge, Norrtälje, Södertälje" },
                        {"Gotland","Gotland"},
                        {"Västra Götaland", "Göteborg, Alingsås, Borås, Dals-Ed, Tranemo, Öckerö, Gullspång"},
                        {"Blekinge","Karlskrona, Karlshamn, Ronneby"}
                        };



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet(pattern: "/json", requestDelegate: async context =>
{
    context.Response.ContentType = "text/plain; charset=utf-8";
    await context.Response.WriteAsJsonAsync(regions);
});

app.MapGet(pattern: "/txt", requestDelegate: async context =>
{
    context.Response.ContentType = "text/plain; charset=utf-8";
    foreach (var kvp in regions)
    {
        var region = kvp.Key;
        var municipalityName = kvp.Value;
        await context.Response.WriteAsync(region + ": ");
        await context.Response.WriteAsync(municipalityName + "\n");
    }
});
app.Run();


