namespace BlazorApp.Model
{
    public class AssignmentService
    {
        private readonly List<Assignment> assignments = new();
        private readonly List<Submission> submissions = new();

        public void AddAssignment(Assignment assignment)
        {
            Console.WriteLine(assignment.Title);
            assignments.Add(assignment);
        }

        public List<Assignment> GetAssignments()
        {
            return assignments;
        }

        public void AddSubmission(Submission submission)
        {
            submissions.Add(submission);
        }

        public List<Submission> GetSubmissions(int assignmentId)
        {
            return submissions.Where(s => s.AssignmentId == assignmentId).ToList();
        }
    }
}
