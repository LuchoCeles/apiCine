using System.Runtime.InteropServices;
using ATDapi.Responses;
using ATDapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ATDapi.Controllers;


[ApiController]

public class CombosController : ControllerBase
{
    public static List<CombosModel> DataList = new List<CombosModel>();

    [HttpGet]
    [Route("CombosController/Get")]
    public BaseResponse Get()
    {
        return new DataResponse<List<CombosModel>>(true, (int)HttpStatusCode.OK, "Lista de cartelera", DataList);
    }

    [HttpPost]
    [Route("CombosController/Create")]
    public BaseResponse Post([FromBody] CombosModel dataInput)
    {
        DataList.Add(dataInput);
        return new BaseResponse(true, (int)HttpStatusCode.Created, "Creado");
    }

    [HttpDelete]
    [Route("CombosController/Delete")]
    public BaseResponse Delete([FromQuery] Guid id)
    {
        CombosModel? n = DataList.FirstOrDefault(x => x.id == id);
        if (n == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.NotFound, "El objeto no fue encontrado");
        }
        else
        {
            DataList.Remove(n);
            return new BaseResponse(true, (int)HttpStatusCode.OK, "Objeto parcialmente eliminado");
        }
    }

    [HttpPut]
    [Route("CombosController/Modificar")]
    public BaseResponse Modificar([FromBody] CombosModel dataInput)
    {
        int i = DataList.FindIndex(x => x.id == dataInput.id);
        if (dataInput.combo != null) DataList[i].combo = dataInput.combo;
        if (dataInput.descripcion != null) DataList[i].descripcion = dataInput.descripcion;
        if (dataInput.precio != null) DataList[i].precio = dataInput.precio;
        if (dataInput.url != null) DataList[i].url = dataInput.url;
        return new BaseResponse(true, (int)HttpStatusCode.Created, "Modificado");
    }
}