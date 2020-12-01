using System.Collections.Generic;

namespace DiaryMVC.Models
{
    public class DiaryViewMode
    {
        public static readonly DiaryViewMode List = new DiaryViewMode("list-mode", "List");
        public static readonly DiaryViewMode Day = new DiaryViewMode("day-mode", "Day");

        public static readonly List<DiaryViewMode> All = new List<DiaryViewMode>() { List, Day };

        public string Key { get; }

        public string Name { get; set; }

        private DiaryViewMode(string key, string name)
        {
            Key = key;
            Name = name;
        }

        public static DiaryViewMode GetMode(string key)
        {
            var mode = All.Find(m => m.Key.Equals(key));
            return mode;
        }
    }
}