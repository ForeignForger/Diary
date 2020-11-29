using DiaryDAL.Entities;
using DiaryMVC.Models;

namespace DiaryMVC.Mappers
{
    public static class TaskMapper
    {
        public static TaskModel Map(Note note)
        {
            var task = new TaskModel
            {
                Id = note.Id,
                Title = note.Title,
                DateTime = note.DateTime,
                DueDateTime = note.DueDateTime.Value,
                Done = note.Done
            };

            return task;
        }
    }
}