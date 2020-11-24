using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Models;

namespace DiaryMVC.Services.Impl
{
    public class TaskService: ITaskService
    {
        private readonly INoteRepository _noteRepository;

        public TaskService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public bool Create(TaskModel model)
        {
            var note = new Note()
            {
                Title = model.Title,
                Type = NoteType.Task,
                DateTime = model.DateTime,
                DueDateTime = model.DueDateTime,
                Done = false
            };

            var createdTask = _noteRepository.Create(note);
            return true;
        }

        public bool Update(TaskModel model)
        {
            var note = new Note()
            {
                Id = model.Id,
                Title = model.Title,
                Type = NoteType.Task,
                DateTime = model.DateTime,
                DueDateTime = model.DueDateTime,
            };

            var updated = _noteRepository.Update(note);
            return updated;
        }
    }
}