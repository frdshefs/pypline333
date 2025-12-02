using SmartTaskManager.Models;

namespace SmartTaskManager.Services;

public class TaskAnalyzer
{
    private readonly ITaskService _taskService;

    public TaskAnalyzer(ITaskService taskService) => _taskService = taskService;

    public AnalysisResult AnalyzeTasks()
    {
        var pending = _taskService.GetPendingTasks();
        var high = _taskService.GetHighPriorityTasks();

        return new AnalysisResult
        {
            TotalTasks = pending.Count,
            HighPriorityCount = high.Count,
            UrgentTasks = high.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == DateTime.Today).ToList(),
            HasCriticalTasks = high.Any(t => t.Priority == TaskPriority.Critical)
        };
    }
}
