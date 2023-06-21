using Microsoft.AspNetCore.Http;
using REST_Api_Bicycle;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Bicycle> bicucles = new List<Bicycle>()
{ new Bicycle { Id = Guid.NewGuid().ToString(), Brand = "NJU", Model = "JHj", Price = 10 },
new Bicycle { Id = Guid.NewGuid().ToString(), Brand = "POI", Model = "MHO", Price = 20},
new Bicycle { Id = Guid.NewGuid().ToString(), Brand = "CRTR", Model = "PLO", Price = 30 },
new Bicycle { Id = Guid.NewGuid().ToString(), Brand = "QAZ", Model = "TUP", Price = 40 },
new Bicycle { Id = Guid.NewGuid().ToString(), Brand = "KMU", Model = "PLI", Price = 50 }};

app.Run(async (context) =>
{
    var request = context.Request;
    var path = request.Path;
    var response = context.Response;

    if(path=="/home")
    {
        response.ContentType = "text/html; setchar=utf-8";
       await response.SendFileAsync("pages/index.html");
    }
    else if (path == "/api/bicycles/")
    {
        if(request.Method == "GET")
        {
            await GetAllListBicycle(response);
        }
        else if(request.Method == "POST")
        {

        }
        else if (request.Method == "PUT")
        {

        }
        else if (request.Method == "DELETE")
        {

        }
        else
        {
            response.ContentType = "text/html; charset=utf-8";
            await response.SendFileAsync("pages/product.html");
        }
    }
    else if(path == "/about")
    {
        response.ContentType = "text/html; setchar=utf-8";
        await response.SendFileAsync("pages/about.html");
    }
    else if (path == "/contacts")
    {
        response.ContentType = "text/html; setchar=utf-8";
        await response.SendFileAsync("pages/contacts.html");
    }

});

app.Run();

async Task GetAllListBicycle(HttpResponse httpResponse)
{
   await httpResponse.WriteAsJsonAsync(bicucles);
}