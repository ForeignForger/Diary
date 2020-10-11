using DiaryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DiaryDAL.Strategies.InitializationStrategies
{
    public class DiaryDbDebugInitializer: DropCreateDatabaseIfModelChanges<DiaryDbContext>
    {
        protected override void Seed(DiaryDbContext context)
        {
            if (!context.Notes.Any())
            {
                var notes = new List<Note>
                {
                    new Note()
                    {
                        Title = "done old memo",
                        Type = NoteType.Memo,
                        DateTime = DateTime.Now.AddDays(-1),
                        Done = true
                    },
                    new Note()
                    {
                        Title = "new cool memo",
                        Type = NoteType.Memo,
                        DateTime = DateTime.Now,
                        Done = false
                    },
                    new Note()
                    {
                        Title = "task, task task",
                        Type = NoteType.Task,
                        DateTime = DateTime.Now.AddDays(2),
                        DueDateTime = DateTime.Now.AddDays(5),
                        Done = false
                    },
                    new Note()
                    {
                        Title = "Oh, you need to meet someone",
                        Type = NoteType.Meeting,
                        DateTime = DateTime.Now.AddDays(10),
                        DueDateTime = DateTime.Now.AddDays(11),
                        Place = "the best place I know",
                        Done = false
                    },
                    new Note()
                    {
                        Title = "Don't forget the thing",
                        Type = NoteType.Memo,
                        DateTime = DateTime.Now.AddDays(-1),
                        Done = true
                    },
                };

                context.Notes.AddRange(notes);
                context.SaveChanges();
            }
        }
    }
}
