using Microsoft.EntityFrameworkCore;
using CompanyManagement.Models;
namespace CompanyManagement.Data;

public class ScheduleRepository : IScheduleRepository
{
    private readonly CompanyManagementDbContext _dbcontext;
    public ScheduleRepository(CompanyManagementDbContext dbContext) => _dbcontext = dbContext;
    public async Task<bool> Add(Schedule schedule)
    {
        var ScheduleExists = await _dbcontext.schedule.FindAsync(schedule.schedule_id);
        if (ScheduleExists != null) return false;
        await _dbcontext.schedule.AddAsync(schedule);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> Delete(string scheduleId)
    {
        var ScheduleExists = await _dbcontext.schedule.FindAsync(scheduleId);
        if (ScheduleExists == null) return false;
        _dbcontext.Remove(scheduleId);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<Schedule>> GetAll()
    {
        var Schedules = await _dbcontext.schedule.ToListAsync();
        return Schedules == null ? Enumerable.Empty<Schedule>() : Schedules;
    }

    public async Task<Schedule> Update(string scheduleId, Schedule schedule)
    {
        var ScheduleExists = await _dbcontext.schedule.FindAsync(scheduleId);
        if (ScheduleExists != null)
        {
            ScheduleExists.date = schedule.date;
            ScheduleExists.note = schedule.note;
            ScheduleExists.time_start = schedule.time_start;
            ScheduleExists.time_end = schedule.time_end;
            await _dbcontext.SaveChangesAsync();
        }
        return ScheduleExists;
    }
    public async Task<Schedule> GetOne(string ScheduleId)
    {
        var ScheduleExists = await _dbcontext.schedule.FindAsync(ScheduleId);
        return ScheduleExists;
    }

}