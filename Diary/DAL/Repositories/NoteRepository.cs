using DiaryDAL.Entities;
using DiaryDAL.Strategies.InitializationStrategies;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DiaryDAL.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly DiaryDbContext _context;

        public NoteRepository(DiaryDbContext context)
        {
            _context = context;
        }

        List<Note> INoteRepository.GetNotes()
        {
            var notes = _context.Notes.ToList();

            return notes;
        }

        Note INoteRepository.CreateNote(Note note)
        {
            var newNote = _context.Notes.Add(note);
            _context.SaveChanges();
            return newNote;
        }

        bool INoteRepository.DeleteNote(int id)
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

        bool INoteRepository.UpdateNote(Note note)
        {
            bool updated;

            var existingNote = _context.Notes.Find(note.Id);

            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.DateTime = note.DateTime;
                existingNote.DueDateTime = note.DueDateTime;
                existingNote.Place = note.Place;

                updated = true;
            }
            else
            {
                updated = false;
            }

            return updated;
        }

        bool INoteRepository.SetNoteStatus(int id, bool done)
        {
            bool updated;

            var existingNote = _context.Notes.Find(id);

            if (existingNote != null)
            {
                existingNote.Done = done;
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
