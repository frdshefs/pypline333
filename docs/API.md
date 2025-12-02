# API Документация Smart Task Manager

## Методы ITaskService
- `AddTask(TaskItem task)` — добавляет задачу
- `CompleteTask(int id)` — завершает задачу
- `GetPendingTasks()` — возвращает незавершённые задачи
- `GetHighPriorityTasks()` — возвращает высокоприоритетные задачи
- `SaveTasksToFile(string path)` — сохраняет в JSON
- `LoadTasksFromFile(string path)` — загружает из JSON

## Анализ
- `AnalyzeTasks()` — возвращает AnalysisResult с отчётом
