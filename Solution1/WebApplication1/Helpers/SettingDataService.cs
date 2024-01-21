using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class SettingDataService
    {
        ExamDay5DBContext _db { get; }

        public SettingDataService(ExamDay5DBContext db)
        {
            _db = db;
        }
        public async Task<setting> GetSettingDataAsync()
        {
            return await _db.setting.FindAsync(1);
        }
    }
}
