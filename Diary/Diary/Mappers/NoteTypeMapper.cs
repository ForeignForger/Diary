using System;
using NoteTypeModel = DiaryMVC.Models.NoteType;
using NoteTypeData = DiaryDAL.Entities.NoteType;

namespace DiaryMVC.Mappers
{
    public class NoteTypeMapper
    {
        public static NoteTypeModel Map(NoteTypeData data)
        {
            NoteTypeModel model;

            switch (data)
            {
                case NoteTypeData.Memo:
                        model = NoteTypeModel.Memo;
                        break;
                case NoteTypeData.Meeting:
                        model = NoteTypeModel.Meeting;
                        break;
                case NoteTypeData.Task:
                        model = NoteTypeModel.Task;
                        break;
                default:
                    throw new ArgumentException($"Couldn't map unexpected note type: {data}");
            }

            return model;
        }
    }
}