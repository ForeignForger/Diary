using DiaryDAL.Entities;
using DiaryDAL.Repositories;
using DiaryMVC.Models;
using DiaryMVC.Services;
using DiaryMVC.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;

namespace DiaryMVCTests.Services
{
    [TestClass]
    public class MemoServiceTests
    {
        [TestMethod]
        public void ShouldCreate()
        {
            var model = new MemoModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Create(Arg<Note>.Matches(x => x.Title == model.Title && x.DateTime == model.DateTime && x.Type == NoteType.Memo))).Return(null);

            IMemoService memoService = new MemoService(noteRepositoryMock);

            var result = memoService.Create(model);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldUpdate()
        {
            var model = new MemoModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Update(Arg<Note>.Matches(x => x.Id == model.Id && x.Title == model.Title && x.DateTime == model.DateTime && x.Type == NoteType.Memo))).Return(true);

            IMemoService memoService = new MemoService(noteRepositoryMock);

            var result = memoService.Update(model);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotUpdated()
        {
            var model = new MemoModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Update(Arg<Note>.Matches(x => x.Id == model.Id))).Return(false);

            IMemoService memoService = new MemoService(noteRepositoryMock);

            var result = memoService.Update(model);

            Assert.IsFalse(result);
            noteRepositoryMock.VerifyAllExpectations();
        }
    }
}
