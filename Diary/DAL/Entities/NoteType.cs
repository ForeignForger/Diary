using System;

namespace DiaryDAL.Entities
{
    /// <summary>
    /// Types of notes in database.
    /// </summary>
    [Flags]
    public enum NoteType: short
    {
        None = 0,
        Memo = 1,
        Task = 2,
        Meeting = 4
    }
}
