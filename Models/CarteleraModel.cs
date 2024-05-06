using System.Runtime.InteropServices;
namespace ATDapi.Models;


public class CarteleraModel
{
    public Guid? id { get; set; } // para que este valor pueda ser null ?
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public string genero { get; set; }
    public string director { get; set; }
    public string actores { get; set; }
    public string url { get; set; } // href ??
}