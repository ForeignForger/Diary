namespace DiaryMVC.Models
{
    public class NoteType
    {
        public static readonly NoteType Memo = new NoteType("Memo");

        public static readonly NoteType Task = new NoteType("Task");

        public static readonly NoteType Meeting = new NoteType("Meeting");

        public string Name { get; }

        public NoteType(string name)
        {
            Name = name;
        }
    }
}