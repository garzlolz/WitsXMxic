using Microsoft.EntityFrameworkCore;

namespace WitsXMxic.Models.DBModels
{
    public class WitsXMxicContext(DbContextOptions<WitsXMxicContext> options)
        : DbContext(options)
    {
        /// <summary>
        /// 後台使用者
        /// </summary>
        public DbSet<HankTeam> HankTeams { get; set; }
    }
}
