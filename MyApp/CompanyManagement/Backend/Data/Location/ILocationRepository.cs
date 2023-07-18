using CompanyManagement.Models;

namespace CompanyManagement.Data;

public interface ILocationRepository
{
    Task<IEnumerable<Province>> GetProvince();
    // Task<Province> GetFullLocation(string provinceId);
    Task<IEnumerable<District>> GetDistrict(string provinceId);
    Task<IEnumerable<Ward>> GetWard(string districtId);
}