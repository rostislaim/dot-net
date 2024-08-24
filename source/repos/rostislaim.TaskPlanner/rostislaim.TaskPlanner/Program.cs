using System;
using System.Collections.Generic;
using System.Linq;
using rostislaim.TaskPlanner.Domain.Models;
using rostislaim.TaskPlanner.Domain.Models.Enums;
using rostislaim.TaskPlanner.Domain.Logic;

internal static class Program
{
    public static void Main(string[] args)
    {
        // Создаем список для хранения WorkItem
        var workItems = new List<WorkItem>();

        Console.WriteLine("Введите количество WorkItem:");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Некорректное количество.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите данные для WorkItem {i + 1}:");

            // Ввод Title
            Console.Write("Title: ");
            string title = Console.ReadLine();

            // Ввод Description
            Console.Write("Description: ");
            string description = Console.ReadLine();

            // Ввод CreationDate
            Console.Write("CreationDate (yyyy-MM-dd): ");
            DateTime creationDate;
            while (!DateTime.TryParse(Console.ReadLine(), out creationDate))
            {
                Console.Write("Некорректный формат даты. Попробуйте еще раз (yyyy-MM-dd): ");
            }

            // Ввод DueDate
            Console.Write("DueDate (yyyy-MM-dd): ");
            DateTime dueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.Write("Некорректный формат даты. Попробуйте еще раз (yyyy-MM-dd): ");
            }

            // Ввод Priority
            Console.Write("Priority (High, Medium, Low): ");
            Priority priority;
            while (!Enum.TryParse(Console.ReadLine(), true, out priority))
            {
                Console.Write("Некорректное значение. Попробуйте еще раз (High, Medium, Low): ");
            }

            // Ввод Complexity
            Console.Write("Complexity (Simple, Medium, Complex): ");
            Complexity complexity;
            while (!Enum.TryParse(Console.ReadLine(), true, out complexity))
            {
                Console.Write("Некорректное значение. Попробуйте еще раз (Simple, Medium, Complex): ");
            }

            // Добавляем новый WorkItem в список
            workItems.Add(new WorkItem
            {
                Title = title,
                Description = description,
                CreationDate = creationDate,
                DueDate = dueDate,
                Priority = priority,
                Complexity = complexity,
                IsCompleted = false
            });
        }

        // Создаем экземпляр SimpleTaskPlanner и сортируем WorkItems
        var taskPlanner = new SimpleTaskPlanner();
        var sortedWorkItems = taskPlanner.CreatePlan(workItems.ToArray());

        // Выводим отсортированные WorkItems
        Console.WriteLine("\nОтсортированные WorkItems:");
        foreach (var item in sortedWorkItems)
        {
            Console.WriteLine(item);
        }
    }
}
