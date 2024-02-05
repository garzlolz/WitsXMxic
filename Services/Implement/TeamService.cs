using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WitsXMxic.Const;
using WitsXMxic.Models.DBModels;
using WitsXMxic.Models.GeneralModels;
using WitsXMxic.Models.ViewModels;
using WitsXMxic.Services.Interface;

namespace WitsXMxic.Services.Implement
{
    public class TeamService : ITeamService
    {
        private WitsXMxicContext DB { get; set; }

        public TeamService(WitsXMxicContext db)
        {
            DB = db;
        }

        /// <summary>
        /// 取得團員列表
        /// </summary>
        /// <returns></returns>
        public async Task<DataResponse<List<UserModel>?>> GetUsers(string? queryName)
        {
            DataResponse<List<UserModel>?> result = new();

            result.Data = await DB.HankTeams
                .Where(h => queryName.IsNullOrEmpty() || h.Name.Contains(queryName!))
                .Select(h => new UserModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Age = h.Age,
                    BirthDay = h.BirthDay
                })
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// 刪除團員
        /// </summary>
        /// <param name="userId">團員 id</param>
        /// <returns></returns>
        public async Task<ResultResponse> DeleteUser(int userId)
        {
            ResultResponse result = new();
            var now = DateTime.Now;

            var user = await DB.HankTeams
                .Where(a => a.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                result.Status.Code = ResponseCodeMessage.DataNotFoundCode;
                result.Status.Message = ResponseCodeMessage.DataNotFound;
                return result;
            }

            DB.HankTeams.Remove(user);

            await DB.SaveChangesAsync();

            return result;
        }

        /// <summary>
        /// 取得團員
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DataResponse<UserModel>> GetUser(int userId)
        {
            DataResponse<UserModel> result = new()
            {
                Data = await DB.HankTeams
                .Select(a => new UserModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Age = a.Age,
                    BirthDay = a.BirthDay
                })
                .FirstOrDefaultAsync(a => a.Id == userId)
            };

            if (result.Data == null)
            {
                result.Status.Code = ResponseCodeMessage.DataNotFoundCode.ToString();
                result.Status.Message = ResponseCodeMessage.DataNotFound;
            }

            return result;
        }

        /// <summary>
        /// 新增/編輯 團員
        /// </summary>
        /// <param name="model">後台帳號 model</param>
        /// <returns></returns>
        public async Task<ResultResponse> CreateOrUpdateUser(UserModel model)
        {
            ResultResponse result = new();
            HankTeam? team;

            // update 驗證 admin 是否存在
            if (model.Id.HasValue)
            {
                team = await DB.HankTeams
                    .FirstOrDefaultAsync(a => a.Id == model.Id);
            }
            else
            {
                team = new();
            }

            if (team == null)
            {
                result.Status.Code = ResponseCodeMessage.DataNotFoundCode;
                result.Status.Message = ResponseCodeMessage.DataNotFound;
                return result;
            }

            // 驗證帳號與名稱是否重複
            var existName = await DB.HankTeams
                 .FirstOrDefaultAsync(a => a.Id != model.Id
                    && a.Name == model.Name);

            if (existName != null)
            {
                result.Status.Code = ResponseCodeMessage.ExistNameCode;
                result.Status.Message = ResponseCodeMessage.ExistName;
                return result;
            }

            team.Name = model.Name!;
            team.Age = model.Age!.Value;
            team.BirthDay = model.BirthDay!.Value;

            if (!model.Id.HasValue)
            {
                await DB.AddAsync(team);
            }

            await DB.SaveChangesAsync();

            return result;
        }
    }
}
