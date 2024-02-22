using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WitsXMxic.Const;

namespace WitsXMxic.Controllers;

public class BaseController : Controller
{
    public BaseController()
    {
    }

    /// <summary>
    /// 將Response訊息放進TempData
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    protected void StoreResponseMessageInTempData(string code, string message)
    {
        TempData[TempDataKeys.Code] = code;
        TempData[TempDataKeys.Message] = message;
    }

    /// <summary>
    /// 將Object放進TempData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="key"></param>
    protected void StoreObjectInTempData<T>(T obj, string key)
    {
        var jsonString = JsonSerializer.Serialize(obj);
        TempData[key] = jsonString;
        TempData.Keep(key);
    }

    /// <summary>
    /// 從TempData取出Object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    protected T? GetObjectFromTempData<T>(string key)
    {
        var jsonString = TempData[key]?.ToString();
        if (string.IsNullOrEmpty(jsonString))
        {
            return default;
        }
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    /// <summary>
    /// 取得Controller名稱
    /// </summary>
    /// <param name="className"></param>
    /// <returns></returns>
    protected string GetControllerName(string className)
    {
        return className.Replace("Controller", string.Empty);
    }
}
