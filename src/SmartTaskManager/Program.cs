using Microsoft.Extensions.DependencyInjection;
using SmartTaskManager.Models;
using SmartTaskManager.Services;

var services = new ServiceCollection();
services.AddSingleton<ITaskService, TaskService>();
services.AddTransient<TaskAnalyzer>();

var provider = services.BuildServiceProvider();
var taskService = provider.GetRequiredService<ITaskService>();
var analyzer = provider.GetRequiredService<TaskAnalyzer>();

taskService.AddTask(new TaskItem { Title = "Настроить CI/CD пайплайн", Description = "Добавить кэширование и условия", Priority = TaskPriority.High });
taskService.AddTask(new TaskItem { Title = "Написать документацию", Description = "Описание API методов", Priority = TaskPriority.Medium });
taskService.AddTask(new TaskItem { Title = "Исправить критический баг", Description = "Падение при загрузке файлов", Priority = TaskPriority.Critical, DueDate = DateTime.Today });

var result = analyzer.AnalyzeTasks();
result.PrintReport();

taskService.SaveTasksToFile("tasks.json");
Console.WriteLine("Приложение Smart Task Manager запущено успешно!");
