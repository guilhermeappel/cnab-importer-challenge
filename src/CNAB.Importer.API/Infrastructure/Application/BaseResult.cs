namespace CNAB.Importer.API.Infrastructure.Application;

public class BaseResult
{
    public Dictionary<string, List<string>> Errors { get; set; }

    public dynamic? Response { get; set; }

    public BaseResult()
    {
        Errors = new Dictionary<string, List<string>>();
        Response = default;
    }

    public bool IsValid() => !Errors.Any();
}