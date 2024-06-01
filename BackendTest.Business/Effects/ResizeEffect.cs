using ClassLibrary1.DTO;
using ClassLibrary1.Interfaces;

namespace ClassLibrary1.Effects;

public class ResizeEffect: IImageEffect
{
    public string Name => "Resize";

    public void Apply(ImageDTO imageDto, Dictionary<string, int> parameters)
    {
        if (parameters.ContainsKey("Width"))
        {
            int width = (int)parameters["Width"];
            Console.WriteLine($"Resizing image {imageDto.Name} to width {width}.");
        }
    }
}