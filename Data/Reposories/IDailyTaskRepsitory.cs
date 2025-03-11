using Data.Models;

namespace Data.Reposories
{
    public interface IDailyTaskRepsitory
    {
        Task<DailyTask> CreateDailyTask(DailyTask dailyTask);
        Task<DailyTask> DeleteDailyTask(int id);
        Task<IEnumerable<DailyTask>> GetDailyTask();
        Task<DailyTask> GetDailyTaskById(int id);
        Task<DailyTask> UpdateDailyTask(DailyTask dailyTask);
    }
}