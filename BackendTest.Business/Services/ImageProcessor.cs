using ClassLibrary1.DTO;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Services;

public class ImageProcessor : IImageProcessor
{
    private List<ImageDTO> _images = new List<ImageDTO>();
    private Dictionary<string, IImageEffect> _effects = new Dictionary<string, IImageEffect>();

    public void AddImage(ImageDTO imageDto)
    {
        var image = this._images.FirstOrDefault(x => x.Name == imageDto.Name);
        if (image != null)
        {
            throw new Exception($"Image already exists.");
        }
        this._images.Add(imageDto);
    }

    public void RegisterEffect(IImageEffect effect)
    {
        this._effects[effect.Name] = effect;
    }

    public void Update(int id, ImageUpdateRequest request)
    {
        var image = this._images.FirstOrDefault(img => img.Id == id);
        
        if (image == null)
        {
            throw new Exception($"Image not found.");
        }

        if (image.Effect != null && image.Effect.ContainsKey(request.EffectName))
        {
            throw new Exception($"Image already contain this effect.");
        }

        if (!this._effects.ContainsKey(request.EffectName))
        {
            throw new Exception($"Effect {request.EffectName} not registered.");
        }

        image.Effect ??= new Dictionary<string, IImageEffect>();
        image.Effect.Add(request.EffectName, this._effects[request.EffectName]);

    }

    public List<ImageDTO> GetImages(ImagesFilterRequest requst)
    {
        int skip = (requst.PageNumber - 1) * requst.PageSize;
        return this._images.Skip(skip).Take(requst.PageSize).ToList();
    }

    public Dictionary<string, IImageEffect> GetEffect()
    {
        return this._effects;
    }

    public ImageDTO GetImage(int id)
    {
        var image = this._images.FirstOrDefault(img => img.Id == id);
        if (image == null)
        {
            throw new Exception($"Image not found.");
        }

        return image;
    }
}