using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Models;
using DiaryMVC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;

namespace DiaryMVCTests.Services
{
    [TestClass]
    public class NoteServiceTests
    {
        [TestMethod]
        public void ShouldGetNotes()
        {
            var notes = new List<Note>() { new Note() { Id = 1, Title = "test title 1" }, new Note() { Id = 2, Title = "another test title 2" } };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.GetNotes(null, null, NoteType.None)).Return(notes);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var resultNotes = noteService.GetNotes(null, null, new List<NoteTypeModel>());

            Assert.AreEqual(notes, resultNotes, "should return correct notes");
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldCreateMemo()
        {
            var noteModel = new NoteModel()
            {
                Title = "title",
                Type = NoteTypeModel.Memo,
                DateTime = DateTime.UtcNow,            
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.CreateNote(Arg<Note>.Matches( x => x.Type == NoteType.Memo))).Return(null);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var result = noteService.CreateNote(noteModel);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldCreateTask()
        {
            var noteModel = new NoteModel()
            {
                Title = "title",
                Type = NoteTypeModel.Task,
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.Now,
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.CreateNote(Arg<Note>.Matches(x => x.Type == NoteType.Task))).Return(null);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var result = noteService.CreateNote(noteModel);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldCreateMeeting()
        {
            var noteModel = new NoteModel()
            {
                Title = "title",
                Type = NoteTypeModel.Meeting,
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.Now,
                Place = "cool place",
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.CreateNote(Arg<Note>.Matches(x => x.Type == NoteType.Meeting))).Return(null);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var result = noteService.CreateNote(noteModel);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }
    }
}
