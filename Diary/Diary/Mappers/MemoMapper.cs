using DiaryDAL.Entities;
using DiaryMVC.Models;

namespace DiaryMVC.Mappers
{
    public static class MemoMapper
    {
        public static MemoModel Map(Note note)
        {
            var memo = new MemoModel
            {
                Id = note.Id,
                Title = note.Title,
                DateTime = note.DateTime,
                Done = note.Done
            };

            return memo;
        }
    }
}