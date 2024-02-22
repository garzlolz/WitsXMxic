using WitsXMxic.Const;

namespace WitsXMxic.Models.GeneralModels;

/// <summary>
/// 回傳狀態
/// </summary>
public class StatusResponse
{
    /// <summary>
    /// 狀態碼
    /// </summary>
    public string Code { get; set; } = ResponseCodeMessage.SuccessCode.ToString();
    /// <summary>
    /// 訊息
    /// </summary>
    public string Message { get; set; } = ResponseCodeMessage.SuccessMessage;
}

/// <summary>
/// 回傳結果
/// </summary>
public class ResultResponse
{
    /// <summary>
    /// 回傳狀態
    /// </summary>
    public StatusResponse Status { get; set; } = new();
}

/// <summary>
/// 泛型回傳值
/// </summary>
/// <typeparam name="T">泛型物件</typeparam>
public class DataResponse<T> : ResultResponse
{
    /// <summary>
    /// 回傳 data
    /// </summary>
    public T? Data { get; set; }
}

/// <summary>
/// 泛型集合回傳值
/// </summary>
/// <typeparam name="T">泛型物件</typeparam>
public class ListResponse<T> : ResultResponse
{
    /// <summary>
    /// 回傳集合
    /// </summary>
    public ICollection<T>? Data { get; set; }
}
