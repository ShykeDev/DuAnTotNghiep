namespace BlazorApp.Model
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string StudentName { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
