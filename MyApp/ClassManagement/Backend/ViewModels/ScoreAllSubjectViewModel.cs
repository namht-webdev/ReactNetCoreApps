namespace ClassManagement.Models;
public class ScoreAllSubjectViewModel
{
    public string StudentId { get; set; }
    public string StudentName { get; set; }
    public ICollection<SubjectScore> SubjectScores { get; set; }
}