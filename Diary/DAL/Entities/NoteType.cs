using System;

namespace DiaryDAL.Entities
{
    /// <summary>
    /// Types of notes in database. Made as a Flag to make filtering easier
    /// </summary>
    [Flags]
    public enum NoteType: short
    {
        Memo = 1,
        Task = 2,
        Meeting = 4,
        All = 7
    }
}
