using System.Runtime.InteropServices;
using ATDapi.Responses;
using ATDapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ATDapi.Controllers;


[ApiController]

public class CarteleraController : ControllerBase
{
    public static List<CarteleraModel> DataList = new List<CarteleraModel>();

    [HttpGet]
    [Route("CarteleraController/Get")]

    public BaseResponse Get()
    {
        return new DataResponse<List<CarteleraModel>>(true, (int)HttpStatusCode.OK, "Lista de cartelera", DataList);
    }

    [HttpPost]
    [Route("CarteleraController/Create")]
    public BaseResponse Post([FromBody] CarteleraModel dataInput)
    {
        DataList.Add(dataInput);
        return new BaseResponse(true, (int)HttpStatusCode.Created, "Creado");
    }

    [HttpDelete]
    [Route("CarteleraController/Delete")]
    public BaseResponse Delete([FromQuery] Guid id)
    {
        CarteleraModel? n = DataList.FirstOrDefault(x => x.id == id);
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
    [Route("CarteleraController/Modificar")]
    public BaseResponse Modificar([FromBody] CarteleraModel dataInput)
    {
        CarteleraModel? tmp = DataList.FirstOrDefault(x => x.id == dataInput.id);
        if (tmp != null)
        {
            DataList.Remove(tmp);
            tmp = dataInput;
            DataList.Add(tmp);
            return new BaseResponse(true, (int)HttpStatusCode.Created, "Modificado");
        }
        else
        {
            return new BaseResponse(true, (int)HttpStatusCode.Created, "No encontrado");
        }
    }
    [HttpPatch]
    [Route("CarteleraController/ModificarParcial")]
    public BaseResponse ModificarParcial([FromBody] CarteleraModel dataInput)//Para mejorar
    {
        if (dataInput.id == null)
        {
            return new BaseResponse(false, (int)HttpStatusCode.BadRequest, "El parametro id es requerido");
        }
        
        CarteleraModel? tmp = DataList.FirstOrDefault(x => x.id == dataInput.id);
        if (tmp != null)
        {
            DataList.Remove(tmp);
            DataList.Add(dataInput);
            return new BaseResponse(true, (int)HttpStatusCode.Created, "Modificado");
        }
        else
        {
            return new BaseResponse(true, (int)HttpStatusCode.Created, "No encontrado");
        }
    }
}