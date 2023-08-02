using Microsoft.EntityFrameworkCore;
using CompanyManagement.Models;
namespace CompanyManagement.Data;

public class RequirementRepository : IRequirementRepository
{
    private readonly CompanyManagementDbContext _dbcontext;
    public RequirementRepository(CompanyManagementDbContext dbContext) => _dbcontext = dbContext;
    public async Task<bool> Add(Requirement requirement)
    {
        var requirementExists = await _dbcontext.requirement.FindAsync(requirement.requirement_id);
        if (requirementExists != null) return false;
        await _dbcontext.requirement.AddAsync(requirement);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<bool> Delete(string requirementId)
    {
        var requirementExists = await _dbcontext.requirement.FindAsync(requirementId);
        if (requirementExists == null) return false;
        _dbcontext.Remove(requirementExists);
        var result = await _dbcontext.SaveChangesAsync();
        return result == 1;
    }

    public async Task<IEnumerable<Requirement>> GetAll()
    {
        var requirements = await _dbcontext.requirement.ToListAsync();
        return requirements == null ? Enumerable.Empty<Requirement>() : requirements;
    }
    public async Task<Requirement> GetOne(string requirementId)
    {
        var requirement = await _dbcontext.requirement.FindAsync(requirementId);
        return requirement;
    }

    public async Task<Requirement> Update(string requirementId, Requirement requirement)
    {
        var requirementExists = await _dbcontext.requirement.FindAsync(requirementId);
        if (requirementExists != null)
        {
            requirementExists.from_user = requirement.from_user;
            requirementExists.to_user = requirement.to_user;
            requirementExists.date = requirement.date;
            requirementExists.request_message = requirement.request_message;
            await _dbcontext.SaveChangesAsync();
        }
        return requirementExists;
    }
}