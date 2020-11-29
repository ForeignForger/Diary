using DiaryDAL.Entities;
using System;
using System.Collections.Generic;

namespace DiaryDAL.Repositories
{
    public interface INoteRepository
    {
        /// <summary>
        /// Get all notes filtered by dates and note type
        /// </summary>
        /// <param name="from">>min date of notes to return (time is ignored)</param>
        /// <param name="to">max date of notes to return (time is ignored)</param>
        /// <param name="noteTypeMask">note types mask</param>
        /// <returns>List of notes</returns>
        List<Note> GetAll(DateTime? from, DateTime? to, NoteType noteTypeMask);

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>note or null if not found</returns>
        Note Get(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="note">note to create</param>
        /// <returns>created note</returns>
        Note Create(Note note);

        /// <summary>
        /// Deletes note from database
        /// </summary>
        /// <param name="id">note id to delete</param>
        /// <returns>true if note has been found and deleted</returns>
        bool Delete(int id);

        /// <summary>
        /// Updates note in database
        /// </summary>
        /// <param name="note">updated note</param>
        /// <returns>true if updated</returns>
        bool Update(Note note);

        /// <summary>
        /// Sets note status
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="done">new status</param>
        /// <returns>true if set</returns>
        bool SetStatus(int id, bool done);
    }
}
