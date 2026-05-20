using Enemix.Models;

namespace Enemix.Services;

public interface IPdfParserService
{
    MaterialEstudo ParsePdfToMaterial(Stream fileStream, AreaConhecimento area);
}