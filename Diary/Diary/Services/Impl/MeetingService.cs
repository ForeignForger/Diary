using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Models;

namespace DiaryMVC.Services.Impl
{
    public class MeetingService : IMeetingService
    {
        private readonly INoteRepository _noteRepository;

        public MeetingService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        bool IMeetingService.Create(MeetingModel model)
        {
            var note = new Note()
            {
                Id = model.Id,
                Title = model.Title,
                Type = NoteType.Meeting,
                DateTime = model.DateTime,
                DueDateTime = model.DueDateTime,
                Place = model.Place,
                Done = false
            };

            var createdNote = _noteRepository.Create(note);
            return true;
        }

        bool IMeetingService.Update(MeetingModel model)
        {
            var note = new Note()
            {
                Id = model.Id,
                Title = model.Title,
                Type = NoteType.Meeting,
                DateTime = model.DateTime,
                DueDateTime = model.DueDateTime,
                Place = model.Place,
            };

            var updated = _noteRepository.Update(note);
            return updated;
        }
    }
}