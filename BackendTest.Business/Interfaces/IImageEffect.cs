using ClassLibrary1.DTO;

namespace ClassLibrary1.Interfaces;

public interface IImageEffect
{
    string Name { get; }
    
    void Apply(ImageDTO imageDto, Dictionary<string, int> parameters);
}