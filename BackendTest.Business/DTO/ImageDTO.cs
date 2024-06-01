using ClassLibrary1.Interfaces;

namespace ClassLibrary1.DTO;

public class ImageDTO: BaseDTO
{
    public string Name { get; set; }
    public string Base64Data { get; set; }
    
    public Dictionary<string, IImageEffect> Effect { get; set; }
    public ImageDTO(string name, string base64Data)
    {
        this.Name = name;
        this.Base64Data = base64Data;
    }
}