using CompanyManagement.Models;
public interface IScheduleRepository
{
    Task<bool> Add(Schedule schedule);
    Task<IEnumerable<Schedule>> GetAll();
    Task<Schedule> GetOne(string scheduleId);
    Task<Schedule> Update(string scheduleId, Schedule schedule);
    Task<bool> Delete(string scheduleId);
}