using System;
using System.Collections.Generic;
using System.Linq;
using rostislaim.TaskPlanner.Domain.Models;
using rostislaim.TaskPlanner.Domain.Models.Enums;

namespace rostislaim.TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        public WorkItem[] CreatePlan(WorkItem[] items)
        {
            // Конвертируем массив в List<WorkItem>
            var itemList = items.ToList();

            // Сортируем List<WorkItem> по критериям
            itemList.Sort((x, y) =>
            {
                // Сортировка по Priority (спаданням)
                int priorityComparison = y.Priority.CompareTo(x.Priority);
                if (priorityComparison != 0)
                {
                    return priorityComparison;
                }

                // Если Priority одинаковый, сортируем по DueDate (зростанням)
                int dueDateComparison = x.DueDate.CompareTo(y.DueDate);
                if (dueDateComparison != 0)
                {
                    return dueDateComparison;
                }

                // Если Priority и DueDate одинаковые, сортируем по Title (алфавітний порядок)
                return string.Compare(x.Title, y.Title, StringComparison.Ordinal);
            });

            // Конвертируем отсортированный List<WorkItem> обратно в массив
            return itemList.ToArray();
        }
    }
}
