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

        public static NoteType Map(NoteTypeModel noteType)
        {
            NoteType data;

            switch (noteType)
            {
                case NoteTypeModel.Memo:
                    data = NoteType.Memo;
                    break;
                case NoteTypeModel.Meeting:
                    data = NoteType.Meeting;
                    break;
                case NoteTypeModel.Task:
                    data = NoteType.Task;
                    break;
                default:
                    throw new ArgumentException($"Couldn't map unexpected note type model: {noteType}");
            }

            return data;
        }
    }
}