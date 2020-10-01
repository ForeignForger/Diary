using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
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
            noteRepositoryMock.Expect(repo => repo.GetNotes()).Return(notes);

            var noteService = new NoteService(noteRepositoryMock);

            var resultNotes = noteService.GetNotes();

            Assert.AreEqual(notes, resultNotes, "should return correct notes");
            noteRepositoryMock.VerifyAllExpectations();
        }
    }
}
