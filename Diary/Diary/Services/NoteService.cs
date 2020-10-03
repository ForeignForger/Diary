using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Models;
using System;
using System.Collections.Generic;

namespace DiaryMVC.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly Dictionary<NoteTypeModel, Func<NoteModel, bool>> _createNoteMethods;
        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
            _createNoteMethods = new Dictionary<NoteTypeModel, Func<NoteModel, bool>>() { { NoteTypeModel.Memo, CreateMemo }, { NoteTypeModel.Task, CreateTask }, { NoteTypeModel.Meeting, CreateMeeting } };
        }
        List<Note> INoteService.GetNotes()
        {
            var notes = _noteRepository.GetNotes();
            return notes;
        }

        bool INoteService.CreateNote(NoteModel noteModel)
        {
            //TODO not in the dictionary, work with exception
            var createMethod = _createNoteMethods[noteModel.Type];

            var created = createMethod(noteModel);
            return created;
        }

        bool INoteService.DeleteNote(int id)
        {
            throw new System.NotImplementedException();
        }

        bool INoteService.UpdateNote(NoteModel noteModel)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        bool INoteService.SetNoteStatus(int id, bool done)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        private bool CreateMemo(NoteModel noteModel)
        {
            var note = new Note()
            {
                Title = noteModel.Title,
                Type = NoteType.Memo,
                DateTime = noteModel.DateTime,
                Done = false
            };

            var createdNote = _noteRepository.CreateNote(note);
            return true;
        }

        private bool CreateTask(NoteModel noteModel)
        {
            var note = new Note()
            {
                Title = noteModel.Title,
                Type = NoteType.Task,
                DateTime = noteModel.DateTime,
                DueDateTime = noteModel.DueDateTime,
                Done = false
            };

            var createdNote = _noteRepository.CreateNote(note);
            return true;
        }

        private bool CreateMeeting(NoteModel noteModel)
        {
            var note = new Note()
            {
                Title = noteModel.Title,
                Type = NoteType.Meeting,
                DateTime = noteModel.DateTime,
                DueDateTime = noteModel.DueDateTime,
                Place = noteModel.Place,
                Done = false
            };

            var createdNote = _noteRepository.CreateNote(note);
            return true;
        }
    }
}