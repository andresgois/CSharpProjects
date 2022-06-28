using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World! 2");
app.MapGet("/user", () => "Andre Gois");
app.MapPost("/user", () => new {name = "Andre", age=33});
app.MapGet("/AddHeader", (HttpResponse response) => {
    response.Headers.Add("Teste","File teste");
    return new {sucess=true, message="ok"} ;   
});
// Enviando informação através do body
app.MapPost("/product", (Product product) => {
    return new {
        Code = product.Code,
        Name = product.Name,
    };
});

// api.app.com/users?datastart={date}&dateend={date2}
app.MapGet("/getproduct", ([FromQuery] string dateStart, [FromQuery] string dateEnd) => {
    return dateStart + " " + dateEnd;
});
// api.app.com/user/{code}
app.MapGet("/getproduct/{code}", ([FromRoute] string code) => {
    return code;
});

// Parâmetro pelo Header
app.MapGet("/getproductbyheader", (HttpRequest request) => {
    return request.Headers["token"].ToString();
});


app.Run();


public class Product{
    public int Code { get; set; }
    public string Name { get; set; }
       
}