using SmartTaskManager.Models;

namespace SmartTaskManager.Services;

public interface ITaskService
{
    void AddTask(TaskItem task);
    void CompleteTask(int taskId);
    List<TaskItem> GetPendingTasks();
    List<TaskItem> GetHighPriorityTasks();
    void SaveTasksToFile(string filePath);
    void LoadTasksFromFile(string filePath);
}
