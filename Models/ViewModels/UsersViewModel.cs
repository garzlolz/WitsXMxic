using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WitsXMxic.Models.ViewModels
{
    /// <summary>
    /// Team Users View Model Model
    /// </summary>
    public class UsersViewModel
    {
        /// <summary>
        /// HankTeam Name Query 
        /// </summary>
        public string? QueryName { get; set; }
        /// <summary>
        /// User Model
        /// </summary>
        public List<UserModel>? Users { get; set; }
    }

    /// <summary>
    /// User Model
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName("姓名")]
        [StringLength(10)]
        public string? Name { get; set; } = null!;
        /// <summary>
        /// 年齡
        /// </summary>
        [DisplayName("年齡")]
        public int? Age { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [DisplayName("生日")]
        public DateTime? BirthDay { get; set; }
    }
}
