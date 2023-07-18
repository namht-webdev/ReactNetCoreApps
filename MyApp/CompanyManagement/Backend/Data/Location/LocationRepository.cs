using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Data;

public class LocationRepository : ILocationRepository
{
    private readonly CompanyManagementDbContext _dbContext;
    public LocationRepository(CompanyManagementDbContext dbContext) => _dbContext = dbContext;
    public async Task<IEnumerable<District>> GetDistrict(string provinceId)
    {
        var result = await _dbContext.district.Where(district => district.province_id == provinceId).ToListAsync();
        return result;
    }

    // public async Task<Province> GetFullLocation(string wardId)
    // {
    //     var ward = await _dbContext.ward.FindAsync(wardId);
    //     if(ward == null) return ward;
    //     var district = await _dbContext.ward.FindAsync(wardId);
    //     if(ward == null) return null;
    //     var result = await _dbContext.province.FindAsync(provinceId);
    //     return result;
    // }

    public async Task<IEnumerable<Province>> GetProvince()
    {
        var result = await _dbContext.province.ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Ward>> GetWard(string districtId)
    {
        var result = await _dbContext.ward.Where(ward => ward.district_id == districtId).ToListAsync();
        return result;
    }
}

