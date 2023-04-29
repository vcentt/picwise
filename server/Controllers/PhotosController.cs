using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using Services.Interface;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class PhotosController : ControllerBase {

    private readonly IPhotoService _photoService;
    private readonly ILogger<PhotosController> _logger;

    public PhotosController(ILogger<PhotosController> logger, IPhotoService photoService)
    {
        _photoService = photoService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Photos>> GetAll()
    {
        try{
            return await _photoService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Photos photo){
        try{
            await _photoService.Add(photo);
            return Ok();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] string photo,string id){
        try{
            await _photoService.Update(id, photo);
            return Ok();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id){
        try{
            await _photoService.Delete(id);
            return Ok();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }  
    }
}
