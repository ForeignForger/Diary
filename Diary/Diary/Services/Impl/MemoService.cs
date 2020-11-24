using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Models;

namespace DiaryMVC.Services.Impl
{
    public class MemoService : IMemoService
    {
        private readonly INoteRepository _noteRepository;

        public MemoService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        bool IMemoService.Create(MemoModel model)
        {
            var note = new Note()
            {
                Title = model.Title,
                Type = NoteType.Memo,
                DateTime = model.DateTime,
                Done = false
            };

            var createdMemo = _noteRepository.Create(note);
            return true;
        }

        bool IMemoService.Update(MemoModel model)
        {
            var note = new Note()
            {
                Id = model.Id,
                Title = model.Title,
                Type = NoteType.Memo,
                DateTime = model.DateTime,
            };

            var updated = _noteRepository.Update(note);
            return updated;
        }
    }
}