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
    public Repository repository = new Repository();
    [HttpGet]
    [Route("CarteleraController/Get")]
    public async Task<BaseResponse> Get()
    {
        try
        {
            var rsp = await repository.GetListBy<dynamic>(CarteleraModel.GetAll());
            return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Lista Creada", data: rsp);
        }
        catch (Exception e)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpGet]
    [Route("CarteleraController/GetById")]
    public async Task<BaseResponse> GetById([FromQuery] int id)
    {
        try
        {
            var rsp = await repository.GetListBy<dynamic>(CarteleraModel.GetById(id));
            return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Objeto Encontrado", data: rsp);
        }
        catch (Exception e)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, e.Message);
        }

    }

    [HttpDelete]
    [Route("CarteleraController/Delete")]
    public async Task<BaseResponse> Delete([FromQuery] int id)
    {
        try
        {
            var rsp = await repository.InsertByQuery(CarteleraModel.Delete(id));
            return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Entidad Borrada Correctamente", data: rsp);
        }
        catch (Exception e)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPut]
    [Route("CarteleraController/Modificar")]
    public async Task<BaseResponse> Modificar([FromBody] CarteleraModel dataInput)
    {
        try
        {
            var rsp = await repository.InsertByQuery(dataInput.Modificar());
            return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Entidad Modificada Correctamente", data: rsp);
        }
        catch (Exception e)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPatch]
    [Route("CarteleraController/ModificarParcial")]
    public async Task<BaseResponse> ModificarParcial([FromBody] CarteleraModel dataInput)//Para mejorar
    {
        try
        {
            var rsp = await repository.InsertByQuery(dataInput.Modificar());
            return new DataResponse<dynamic>(true, (int)HttpStatusCode.OK, "Entidad Modificada Correctamente", data: rsp);
        }
        catch (Exception e)
        {
            return new BaseResponse(false, (int)HttpStatusCode.InternalServerError, e.Message);
        }
    }

    [HttpPost]
    [Route("CarteleraController/PostU")]
    public async Task<IActionResult> PostU([FromForm]CarteleraModel upload)
    {
        if (upload == null || upload.File.Length == 0) return BadRequest("No se proporcionó ningún archivo.");

        //var path = Path.Combine("C:\\Users\\hilet.HILET\\cine\\public\\", upload.File.FileName);
        var path = Path.Combine("C:\\Users\\Usuario\\Desktop\\cine\\img_peliculas\\img_1\\", upload.File.FileName);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await upload.File.CopyToAsync(stream);
        }
        var file = "\\img_peliculas\\img_1\\" + upload.File.FileName;
        upload.url = file;
        await repository.InsertByQuery(upload.Insert());
        return Ok(new { file });
    }
}