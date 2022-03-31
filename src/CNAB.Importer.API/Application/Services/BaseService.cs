using CNAB.Importer.API.Application.ExtensionMethods;
using CNAB.Importer.API.Infrastructure.Application;

namespace CNAB.Importer.API.Application.Services;

public abstract class BaseService
{
    protected BaseResult BaseResult;

    protected BaseService()
    {
        BaseResult = new BaseResult();
    }

    protected void AddError(string key, string value)
    {
        key = key.ToCamelCase();

        if (BaseResult.Errors.ContainsKey(key))
        {
            BaseResult.Errors[key].Add(value);
        }
        else
        {
            BaseResult.Errors.Add(key, new() { value });
        }
    }
}