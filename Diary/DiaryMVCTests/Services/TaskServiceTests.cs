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
    public class TaskServiceTests
    {
        [TestMethod]
        public void ShouldCreate()
        {
            var model = new TaskModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow.AddDays(1),
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Create(Arg<Note>.Matches(x => x.Title == model.Title && x.DateTime == model.DateTime && x.DueDateTime == model.DueDateTime && x.Type == NoteType.Task))).Return(null);

            ITaskService taskService = new TaskService(noteRepositoryMock);

            var result = taskService.Create(model);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldUpdate()
        {
            var model = new TaskModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow.AddDays(1),
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Update(Arg<Note>.Matches(x => x.Id == model.Id && x.Title == model.Title && x.DateTime == model.DateTime && x.DueDateTime == model.DueDateTime && x.Type == NoteType.Task))).Return(true);

            ITaskService taskService = new TaskService(noteRepositoryMock);

            var result = taskService.Update(model);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotUpdated()
        {
            var model = new TaskModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow.AddDays(1),
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Update(Arg<Note>.Matches(x => x.Id == model.Id))).Return(false);

            ITaskService taskService = new TaskService(noteRepositoryMock);

            var result = taskService.Update(model);

            Assert.IsFalse(result);
            noteRepositoryMock.VerifyAllExpectations();
        }
    }
}
