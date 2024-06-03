using System.Runtime.InteropServices;
namespace ATDapi.Models;


public class CarteleraModel
{
    public int? id { get; set; } // para que este valor pueda ser null ?
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public string genero { get; set; }
    public string director { get; set; }
    public string actores { get; set; }
    public string url { get; set; } // href ??

    public static string GetAll()
    {
        var query = string.Format("SELECT * FROM Cartelera;");
        return query;
    }

    public string Insert()
    {
        var query = string.Format("INSERT INTO Cartelera (titulo,descripcion,genero,director,actores,url)" +
            " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", this.titulo, this.descripcion, this.genero, this.director, this.actores, this.url);
        return query;
    }

    public static string GetById(int id)
    {
        return string.Format("SELECT * FROM Cartelera WHERE id_Cartelera IS {0};", id);
    }

    public static string Delete(int id)
    {
        var query = string.Format("DELETE FROM Cartelera WHERE id_Cartelera IS {0};", id);
        return query;
    }

    public string Modificar()
    {
        return string.Format("UPDATE Cartelera SET titulo = '{0}', descripcion = '{1}', genero = '{2}', director = '{3}', actor = '{4}' , url  = '{5}'",  this.titulo, this.descripcion, this.genero, this.director, this.actores, this.url);
    }
}