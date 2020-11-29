using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Models;
using DiaryMVC.Services;
using DiaryMVC.Services.Impl;
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
            noteRepositoryMock.Expect(repo => repo.GetAll(null, null, NoteType.None)).Return(notes);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var resultNotes = noteService.GetAll(null, null, new List<NoteTypeModel>());

            Assert.AreEqual(notes, resultNotes, "should return correct notes");
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldGetNoteById()
        {
            var notes = new List<Note>() { new Note() { Id = 1, Title = "test title 1" }, new Note() { Id = 2, Title = "another test title 2" } };
            var id = 2;

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Get(id)).Return(notes[1]);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var resultNote = noteService.Get(id);

            Assert.AreEqual(notes[1], resultNote, "should return correct note");
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldDeleteNote()
        {
            var id = 1;

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Delete(id)).Return(true);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var result = noteService.Delete(id);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldSetNoteStatus()
        {
            var id = 1;
            var status = true;

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.SetStatus(id, status)).Return(true);

            INoteService noteService = new NoteService(noteRepositoryMock);

            var result = noteService.SetStatus(id, status);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }
    }
}
