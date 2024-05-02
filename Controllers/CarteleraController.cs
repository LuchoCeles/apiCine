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
}