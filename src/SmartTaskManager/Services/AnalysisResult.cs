using SmartTaskManager.Models;

namespace SmartTaskManager.Services;

public class AnalysisResult
{
    public int TotalTasks { get; set; }
    public int HighPriorityCount { get; set; }
    public List<TaskItem> UrgentTasks { get; set; } = new();
    public bool HasCriticalTasks { get; set; }

    public void PrintReport()
    {
        Console.WriteLine("Отчет по задачам:");
        Console.WriteLine($"Всего задач: {TotalTasks}");
        Console.WriteLine($"Высокий приоритет: {HighPriorityCount}");
        Console.WriteLine($"Срочные на сегодня: {UrgentTasks.Count}");
        Console.WriteLine($"Критические задачи: {(HasCriticalTasks ? "ЕСТЬ" : "Нет")}");
    }
}
