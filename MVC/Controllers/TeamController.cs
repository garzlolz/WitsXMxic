using Microsoft.AspNetCore.Mvc;
using WitsXMxic.Const;
using WitsXMxic.Models.ViewModels;
using WitsXMxic.Services.Interface;

namespace WitsXMxic.Controllers
{
    public class TeamController : BaseController
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// 團員列表
        /// </summary>
        /// <param name="queryName"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(string? queryName)
        {
            var getUsers = await _teamService.GetUsers(queryName);

            StoreObjectInTempData(queryName, nameof(this.Index) + TempDataKeys.Query);

            UsersViewModel model = new UsersViewModel
            {
                QueryName = queryName,
                Users = getUsers.Data
            };

            return View(model);
        }

        /// <summary>
        /// 刪除團員
        /// </summary>
        /// <param name="id">團員 id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _teamService.DeleteUser(id);

            StoreResponseMessageInTempData(result.Status.Code, result.Status.Message);

            return Json(result);
        }

        /// <summary>
        /// 新增/編輯頁
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateOrUpdateUser(int? id)
        {
            UserModel model;

            if (!id.HasValue)
            {
                model = new();

                ViewBag.Action = ConstString.Create;
                ViewBag.SubmitButtonText = ConstString.Create;

                return View(model);
            }

            var getAdmin = await _teamService.GetUser(id.Value);

            if (getAdmin.Status.Code != ResponseCodeMessage.SuccessCode || getAdmin.Data == null)
            {
                StoreResponseMessageInTempData(getAdmin.Status.Code, getAdmin.Status.Message);

                var queryName = GetObjectFromTempData<string?>(nameof(this.Index) + TempDataKeys.Query);

                return RedirectToAction(nameof(this.Index), queryName);
            }
            model = getAdmin.Data;

            ViewBag.Action = ConstString.Update;
            ViewBag.SubmitButtonText = ConstString.Save;

            return View(model);
        }

        /// <summary>
        /// 新增/編輯 團員
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateUser(UserModel model)
        {
            var result = await _teamService.CreateOrUpdateUser(model);

            StoreResponseMessageInTempData(result.Status.Code, result.Status.Message);

            if (result.Status.Code == ResponseCodeMessage.SuccessCode)
            {
                var queryModel = GetObjectFromTempData<string?>(nameof(this.Index) + TempDataKeys.Query);

                return RedirectToAction(nameof(this.Index), queryModel);
            }

            if (model.Id.HasValue)
            {
                ViewBag.Action = ConstString.Update;
                ViewBag.SubmitButtonText = ConstString.Save;
            }

            return View(model);
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <returns></returns>
        public IActionResult Cancel()
        {
            var queryName = GetObjectFromTempData<string?>(nameof(this.Index) + TempDataKeys.Query);

            return RedirectToAction(nameof(this.Index), new { queryName });
        }
    }
}
