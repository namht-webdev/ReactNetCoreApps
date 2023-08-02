namespace CompanyManagement.Models;

public class Condition
{
    public bool? orderAscending { get; set; }
    public ICollection<Dictionary<string, string>>? conditions { get; set; }
    public ICollection<Dictionary<string, string>>? orderBy { get; set; }
}