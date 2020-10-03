using DiaryDAL.Entities;
using DiaryMVC.Models;
using System;

namespace DiaryMVC.Mappers
{
    public class NoteTypeMapper
    {
        public static NoteTypeModel Map(NoteType data)
        {
            NoteTypeModel model;

            switch (data)
            {
                case NoteType.Memo:
                        model = NoteTypeModel.Memo;
                        break;
                case NoteType.Meeting:
                        model = NoteTypeModel.Meeting;
                        break;
                case NoteType.Task:
                        model = NoteTypeModel.Task;
                        break;
                default:
                    throw new ArgumentException($"Couldn't map unexpected note type: {data}");
            }

            return model;
        }
    }
}