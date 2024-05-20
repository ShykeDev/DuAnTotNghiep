// Hubs/AssignmentHub.cs
using BlazorApp.Model;
using Microsoft.AspNetCore.SignalR;

public class AssignmentHub : Hub
{
    private readonly AssignmentService _assignmentService;

    public AssignmentHub(AssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    public async Task SendAssignment(Assignment assignment)
    {
        _assignmentService.AddAssignment(assignment);
        await Clients.All.SendAsync("ReceiveAssignment", assignment);
        Console.WriteLine($"Created AssignmentHub: {Context.ConnectionId}");
    }

    public async Task SubmitAssignment(Submission submission)
    {
        _assignmentService.AddSubmission(submission);
        await Clients.Group(submission.AssignmentId.ToString()).SendAsync("ReceiveSubmission", submission);
        Console.WriteLine($"Created AssignmentHub: {Context.ConnectionId}");

    }

    public async Task JoinAssignmentGroup(int assignmentId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, assignmentId.ToString());
    }

    public async Task LeaveAssignmentGroup(int assignmentId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, assignmentId.ToString());
    }
}
