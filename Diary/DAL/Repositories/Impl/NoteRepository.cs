using DiaryDAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DiaryDAL.Repositories.Impl
{
    public class NoteRepository : INoteRepository
    {
        private readonly DiaryDbContext _context;

        public NoteRepository(DiaryDbContext context)
        {
            _context = context;
        }

        List<Note> INoteRepository.GetAll(DateTime? from, DateTime? to, NoteType noteTypeMask)
        {
            IQueryable<Note> notes = _context.Notes;

            if (from != null)
            {
                notes = notes.Where(note => DbFunctions.TruncateTime(note.DateTime) >= DbFunctions.TruncateTime(from.Value));
            }

            if (to != null)
            {
                notes = notes.Where(note => DbFunctions.TruncateTime(note.DateTime) <= DbFunctions.TruncateTime(to.Value));
            }

            if (noteTypeMask != NoteType.None)
            {
                notes = notes.Where(note => (note.Type & noteTypeMask) == note.Type);
            }

            var result = notes.ToList();
            return result;
        }

        Note INoteRepository.Get(int id)
        {
            var note = _context.Notes.Find(id);
            return note;
        }

        Note INoteRepository.Create(Note note)
        {
            var newNote = _context.Notes.Add(note);
            _context.SaveChanges();
            return newNote;
        }

        bool INoteRepository.Delete(int id)
        {
            bool deleted;
            var note = _context.Notes.Find(id);

            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            return deleted;
        }

        bool INoteRepository.Update(Note note)
        {
            bool updated;

            var existingNote = _context.Notes.Find(note.Id);

            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.DateTime = note.DateTime;
                existingNote.DueDateTime = note.DueDateTime;
                existingNote.Place = note.Place;
                _context.SaveChanges();

                updated = true;
            }
            else
            {
                updated = false;
            }

            return updated;
        }

        bool INoteRepository.SetStatus(int id, bool done)
        {
            bool updated;

            var existingNote = _context.Notes.Find(id);

            if (existingNote != null)
            {
                existingNote.Done = done;
                _context.SaveChanges();
                updated = true;
            }
            else
            {
                updated = false;
            }

            return updated;
        }
    }
}
