using DiaryDAL.Entities;
using DiaryMVC.Models;

namespace DiaryMVC.Mappers
{
    public static class MeetingMapper
    {
        public static MeetingModel Map(Note note)
        {
            var meeting = new MeetingModel
            {
                Id = note.Id,
                Title = note.Title,
                DateTime = note.DateTime,
                DueDateTime = note.DueDateTime.Value,
                Place = note.Place,
                Done = note.Done
            };

            return meeting;
        }
    }
}