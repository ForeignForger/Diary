using DiaryDAL.Entities;
using DiaryMVC.Models;
using System;
using System.Collections.Generic;

namespace DiaryMVC.Services
{
    public interface INoteService
    {
        /// <summary>
        /// Gets all notes and filters them
        /// </summary>
        /// <param name="from">min date of notes to return (time is ignored)</param>
        /// <param name="to">max date of notes to return (time is ignored)</param>
        /// <param name="noteTypes">note types to return(empty list equals All types)</param>
        /// <returns></returns>
        List<Note> GetAll(DateTime? from, DateTime? to, List<NoteTypeModel> noteTypes);

        /// <summary>
        /// Deletes note from database by Id
        /// </summary>
        /// <param name="id">note id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Set note status by id
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="done">new note status</param>
        /// <returns></returns>
        bool SetStatus(int id, bool done);
    }
}
