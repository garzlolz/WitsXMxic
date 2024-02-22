namespace WitsXMxic.Const;

public class ResponseCodeMessage
{
    #region 成功
    public const string SuccessCode = "1";
    public const string SuccessMessage = "成功";
    #endregion

    #region 400 Bad Request
    public const string ExistNameCode = "40001";
    public const string ExistName = "姓名重複已重複";
    #endregion

    #region 404 Data Not Found
    public const string DataNotFoundCode = "44000";
    public const string DataNotFound = "找不到資料";
    #endregion
}
