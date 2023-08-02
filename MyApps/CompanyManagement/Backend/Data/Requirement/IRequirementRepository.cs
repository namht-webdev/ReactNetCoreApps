using CompanyManagement.Models;
public interface IRequirementRepository
{
    Task<bool> Add(Requirement requirement);
    Task<IEnumerable<Requirement>> GetAll();
    Task<Requirement> GetOne(string requirementId);
    Task<Requirement> Update(string requirementId, Requirement requirement);
    Task<bool> Delete(string requirementId);
}