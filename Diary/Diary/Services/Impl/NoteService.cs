using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Mappers;
using DiaryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiaryMVC.Services.Impl
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        List<Note> INoteService.GetAll(DateTime? from, DateTime? to, List<NoteTypeModel> noteTypes)
        {
            var noteTypeDatas = noteTypes.Select(type => NoteTypeMapper.Map(type)).ToList();
            NoteType noteTypeMask = NoteType.None;

            //Creating mask for filtering by note type
            noteTypeDatas.ForEach(noteType => noteTypeMask |= noteType);

            var notes = _noteRepository.GetAll(from, to, noteTypeMask);
            return notes;
        }

        bool INoteService.Delete(int id)
        {
            var result = _noteRepository.Delete(id);

            return result;
        }

        bool INoteService.SetStatus(int id, bool done)
        {
            var result = _noteRepository.SetStatus(id, done);

            return result;
        }
    }
}