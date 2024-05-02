namespace ATDapi.Models;


public class CombosModel
{
    public int? id { get; set; } // para que este valor pueda ser null ?
    public string combo { get; set; }
    public string descripcion { get; set; }
    public float precio { get; set; }
    public string url { get; set; }
}