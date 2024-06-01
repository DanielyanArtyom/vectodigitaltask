using ClassLibrary1.DTO;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Effects;

public class BlurEffect : IImageEffect
{
    public string Name => "Blur";

    public void Apply(ImageDTO imageDto, Dictionary<string, int> parameters)
    {
        if (parameters.ContainsKey("Size"))
        {
            int size = (int)parameters["Size"];
            Console.WriteLine($"Applying blur of size {size} to image {imageDto.Name}.");
        }
    }
}