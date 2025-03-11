using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Reposories
{
    public class DailyTaskRepsitory : IDailyTaskRepsitory
    {
        private readonly DailyTaskContext _dailyTaskContext;
        public DailyTaskRepsitory(DailyTaskContext dailyTaskContext)
        {
            _dailyTaskContext = dailyTaskContext;
        }

        public async Task<IEnumerable<DailyTask>> GetDailyTask()
        {
            var tasks = await _dailyTaskContext.DailyTask.ToListAsync();
            return tasks;
        }
        public async Task<DailyTask> GetDailyTaskById(int id)
        {
            var task = await _dailyTaskContext.DailyTask.FindAsync(id);
            return task;
        }
        public async Task<DailyTask> CreateDailyTask(DailyTask dailyTask)
        {
            _dailyTaskContext.DailyTask.Add(dailyTask);
            await _dailyTaskContext.SaveChangesAsync();
            return dailyTask;
        }
        public async Task<DailyTask> UpdateDailyTask(DailyTask dailyTask)
        {
            _dailyTaskContext.DailyTask.Update(dailyTask);
            await _dailyTaskContext.SaveChangesAsync();
            return dailyTask;
        }
        public async Task<DailyTask> DeleteDailyTask(int id)
        {
            var task = await _dailyTaskContext.DailyTask.FindAsync(id);
            _dailyTaskContext.DailyTask.Remove(task);
            await _dailyTaskContext.SaveChangesAsync();
            return task;
        }

    }
}
