using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SmartTaskManager.Models;

namespace SmartTaskManager.Services;

public class TaskService : ITaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public void AddTask(TaskItem task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
        Console.WriteLine($"Добавлена задача: {task.Title}");
    }

    public void CompleteTask(int taskId)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            task.IsCompleted = true;
            Console.WriteLine($"Завершена задача: {task.Title}");
        }
    }

    public List<TaskItem> GetPendingTasks() => _tasks.Where(t => !t.IsCompleted).ToList();

    public List<TaskItem> GetHighPriorityTasks() => _tasks.Where(t => !t.IsCompleted && (t.Priority == TaskPriority.High || t.Priority == TaskPriority.Critical)).ToList();

    public void SaveTasksToFile(string filePath)
    {
        var json = JsonConvert.SerializeObject(_tasks, Formatting.Indented);
        System.IO.File.WriteAllText(filePath, json);
        Console.WriteLine($"Задачи сохранены в: {filePath}");
    }

    public void LoadTasksFromFile(string filePath)
    {
        if (System.IO.File.Exists(filePath))
        {
            var json = System.IO.File.ReadAllText(filePath);
            var loaded = JsonConvert.DeserializeObject<List<TaskItem>>(json);
            if (loaded != null)
            {
                _tasks.Clear();
                _tasks.AddRange(loaded);
                _nextId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
                Console.WriteLine($"Задачи загружены из: {filePath}");
            }
        }
    }
}
