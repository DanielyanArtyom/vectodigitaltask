using ClassLibrary1.DTO;
using ClassLibrary1.Effects;
using ClassLibrary1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendTestWebapi.Controllers;

public class ImageController : ControllerBase
{
    private readonly IImageProcessor _imageProcessor;
    private readonly Random _rnd;
    public ImageController(IImageProcessor imageProcessor)
    {
        this._imageProcessor = imageProcessor;
        this._rnd = new Random();

        this._imageProcessor.RegisterEffect(new ResizeEffect());
        this._imageProcessor.RegisterEffect(new BlurEffect());
    }

    [HttpPost("add")]
    public ActionResult<int> AddImage([FromBody] ImageRequest request)
    {
        var id = this._rnd.Next();
        var image = new ImageDTO(request.Name, request.Base64Data)
        {
            Id = id
        };
        this._imageProcessor.AddImage(image);
        return Ok(id);
    }

    [HttpPut("update/{id}")]
    public ActionResult<bool> Update(int id, [FromBody] ImageUpdateRequest request)
    {
        try
        {
            this._imageProcessor.Update(id, request);
            return Ok(true);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("images")]
    public ActionResult<List<ImageDTO>> GetImages(ImagesFilterRequest requst)
    {
        var images = this._imageProcessor.GetImages(requst);
        return Ok(images);
    }
    
    [HttpGet("effects")]
    public ActionResult<Dictionary<string, IImageEffect>> GetEffects()
    {
        var images = this._imageProcessor.GetEffect();
        return Ok(images);
    }
    
    [HttpGet("image/{id}")]
    public ActionResult<ImageDTO> GetImage(int id)
    {
        try
        {
            var images = this._imageProcessor.GetImage(id);
            return Ok(images);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}