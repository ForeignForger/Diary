namespace DiaryMVC.Models
{
    //TODO why am I doing it this complicated again? I wanted to have name, but maybe it would be better to create enum NoteType and change this class to NoteTypeModel {string Name,NoteType Type}
    public class NoteTypeModel
    {
        public static readonly NoteTypeModel Memo = new NoteTypeModel("Memo");

        public static readonly NoteTypeModel Task = new NoteTypeModel("Task");

        public static readonly NoteTypeModel Meeting = new NoteTypeModel("Meeting");

        public string Name { get; }

        private NoteTypeModel(string name)
        {
            Name = name;
        }
    }
}