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
    public BaseResponse Delete([FromBody] CombosModel dataInput)
    {
        var n = DataList.FirstOrDefault(x => x.id == dataInput.id);
        if (n != null) DataList.Remove(n);
        return new BaseResponse(true, (int)HttpStatusCode.Created, "Eliminado");
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