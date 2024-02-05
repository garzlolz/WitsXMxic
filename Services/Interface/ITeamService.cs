using WitsXMxic.Models.GeneralModels;
using WitsXMxic.Models.ViewModels;

namespace WitsXMxic.Services.Interface
{
    public interface ITeamService
    {
        /// <summary>
        /// 取得團員列表
        /// </summary>
        /// <returns></returns>
        public Task<DataResponse<List<UserModel>?>> GetUsers(string? queryName);
        /// <summary>
        /// 刪除團員
        /// </summary>
        /// <param name="userId">團員Id</param>
        /// <returns></returns>
        public Task<ResultResponse> DeleteUser(int userId);
        /// <summary>
        /// 取得團員
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<DataResponse<UserModel>> GetUser(int userId);
        /// <summary>
        /// 新增/編輯 團員
        /// </summary>
        /// <param name="model">團員 model</param>
        /// <returns></returns>
        public Task<ResultResponse> CreateOrUpdateUser(UserModel model);
    }
}
