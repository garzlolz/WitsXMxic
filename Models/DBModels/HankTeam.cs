using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WitsXMxic.Models.DBModels
{
    /// <summary>
    /// 後台使用者
    /// </summary>
    [Table("hank_teams")]
    public class HankTeam
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Comment("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(10)]
        [Column("name")]
        [Comment("姓名")]
        public string Name { get; set; } = null!;
        /// <summary>
        /// 年齡
        /// </summary>
        [Required]
        [Column("age")]
        [Comment("年齡")]
        public int Age{ get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Column("birth")]
        [Comment("生日")]
        public DateTime BirthDay { get; set; }
    }
}
