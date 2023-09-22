//primer sedefine la url de la api
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

var url = "https://localhost:44368/compras/ListarCompras";
var urlagregar = "https://localhost:44368/compras/agregarCompra";
var urlmodificar = "https://localhost:44368/compras/actualizarCompra";
var urleliminar = "https://localhost:44368/compras/eliminarCompra";
JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }; //para que ignore diferenciar entre mayuscula y minuscula

using (var httpClient = new HttpClient())
{
    //GET
    /*var response = await httpClient.GetAsync(url); //peticion get
    if(response.IsSuccessStatusCode) //if 200
    { 
        var result = await response.Content.ReadAsStringAsync();
        var compras = JsonSerializer.Deserialize<List<Compras>>(result); 
        foreach(var item in compras)
        {
            Console.WriteLine($"{item.id} {item.nombreProveedor}");
        }
    }
    else { Console.WriteLine("hubo un error"); }*/


    //POST
    /*var response = await httpClient.PostAsJsonAsync(urlagregar, new Compras {
        fechaEmision = DateTime.Parse("2023-09-21"),
        numeroDelDoc = 665767,
        nrc = "string",
        nombreProveedor = "11string",
        comprasExentasInternas = 0,
        comprasImportIntern = 0,
        comprasGrabadasInternas = 0,
        comprasGrabadasImportIntern = 0,
        comprasGrabadasCreditoFiscal = 0,
        anticipoACuentaIvaRetenido = 0,
        anticipoACuentaIvaRecibido = 0,
        total = 0
    });
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Compra agregado");

    }else {Console.WriteLine("Error "); }
    */

    //PATCH
    /*var serializedData = JsonSerializer.Serialize(new Compras
    {
        id = 10,
        fechaEmision = DateTime.Parse("2023-09-21"),
        numeroDelDoc = 8888,
        nrc = "string",
        nombreProveedor = "12string",
        comprasExentasInternas = 0,
        comprasImportIntern = 0,
        comprasGrabadasInternas = 0,
        comprasGrabadasImportIntern = 0,
        comprasGrabadasCreditoFiscal = 0,
        anticipoACuentaIvaRetenido = 0,
        anticipoACuentaIvaRecibido = 0,
        total = 0
    });
    var content = new StringContent(serializedData, Encoding.UTF8, "application/json");
    var response = await httpClient.PatchAsync(urlmodificar, content);
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Compra actualizado");

    }
    else { Console.WriteLine("Error "); }*/

    var serializedData = JsonSerializer.Serialize(new Compras
    {
        id = 10
    });
    var content = new StringContent(serializedData, Encoding.UTF8, "application/json");
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Delete,
        RequestUri = new Uri(urleliminar),
        Content = content
    };
    var response = await httpClient.SendAsync(request);
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine("Compra eliminada");

    }
    else { Console.WriteLine("Error "); }
    Console.ReadKey();

}

public class Compras
{
    public int? id { get; set; }
    public DateTime? fechaEmision { get; set; }
    public int? numeroDelDoc { get; set; }
    public string? nrc { get; set; }
    public string?   nombreProveedor { get; set; }
    public decimal? comprasExentasInternas { get; set; }
    public decimal? comprasImportIntern { get; set; }
    public decimal? comprasGrabadasInternas { get; set; }
    public decimal? comprasGrabadasImportIntern { get; set; }
    public decimal? comprasGrabadasCreditoFiscal { get; set; }
    public decimal? anticipoACuentaIvaRetenido { get; set; }
    public decimal? anticipoACuentaIvaRecibido { get; set; }
    public decimal? total { get; set; } // Cambio de "Total" a "total"
}
