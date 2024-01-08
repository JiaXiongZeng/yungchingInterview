using Microsoft.EntityFrameworkCore;

namespace PseudoEstateAPI.Entities
{
    //寫測試時發現Sqllite位置不能用相對路徑，否則會抓不到
    //故動態調整之
    public partial class YungchingInterviewContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string dir = Directory.GetCurrentDirectory();
            string solutionDir = dir.Substring(0, dir.IndexOf("\\yungchingInterview")) + "\\yungchingInterview";
            optionsBuilder.UseSqlite(@$"Data Source={solutionDir}\yungchingInterview.db");
        }
    }
}
