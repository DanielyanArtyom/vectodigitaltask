using ClassLibrary1.DTO;

namespace ClassLibrary1.Interfaces;

public interface IImageProcessor
{
    public void AddImage(ImageDTO imageDto);

    public void RegisterEffect(IImageEffect effect);

    public void Update(int id, ImageUpdateRequest request);

    public List<ImageDTO> GetImages(ImagesFilterRequest requst);

    public Dictionary<string, IImageEffect> GetEffect();
    
    public ImageDTO GetImage(int id);

}