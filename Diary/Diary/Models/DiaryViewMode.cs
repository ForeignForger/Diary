using System.Collections.Generic;
using System.Linq;

namespace DiaryMVC.Models
{
    public class DiaryViewMode
    {
        public static readonly DiaryViewMode List = new DiaryViewMode("list-mode");

        public static readonly List<DiaryViewMode> All = new List<DiaryViewMode>() { List };

        public string Key { get; }

        private DiaryViewMode(string key)
        {
            Key = key;
        }

        public static DiaryViewMode GetMode(string key)
        {
            var mode = All.Find(m => m.Key.Equals(key));
            return mode;
        }
    }
}