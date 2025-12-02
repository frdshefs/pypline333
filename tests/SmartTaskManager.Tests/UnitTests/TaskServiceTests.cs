using SmartTaskManager.Models;
using SmartTaskManager.Services;
using Xunit;

public class TaskServiceTests
{
    private readonly ITaskService _taskService;

    public TaskServiceTests()
    {
        _taskService = new TaskService();
    }

    [Fact]
    public void AddTask_ShouldAddTask()
    {
        var task = new TaskItem { Title = "Test Task", Priority = TaskPriority.Medium };
        _taskService.AddTask(task);

        var pending = _taskService.GetPendingTasks();
        Assert.Single(pending);
        Assert.Equal("Test Task", pending[0].Title);
    }

    [Fact]
    public void CompleteTask_ShouldMarkAsCompleted()
    {
        var task = new TaskItem { Title = "Test Task", Priority = TaskPriority.Medium };
        _taskService.AddTask(task);

        _taskService.CompleteTask(task.Id);

        var pending = _taskService.GetPendingTasks();
        Assert.Empty(pending);
    }
}
