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
    public class MeetingServiceTests
    {
        [TestMethod]
        public void ShouldCreate()
        {
            var model = new MeetingModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow.AddDays(1),
                Place = "meeting place",
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Create(Arg<Note>.Matches(x => x.Title == model.Title && x.DateTime == model.DateTime && x.DueDateTime == model.DueDateTime && x.Type == NoteType.Meeting))).Return(null);

            IMeetingService meetingService = new MeetingService(noteRepositoryMock);

            var result = meetingService.Create(model);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldUpdate()
        {
            var model = new MeetingModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow.AddDays(1),
                Place = "meeting place",
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Update(Arg<Note>.Matches(x => x.Id == model.Id && x.Title == model.Title && x.DateTime == model.DateTime && x.DueDateTime == model.DueDateTime && x.Place == model.Place && x.Type == NoteType.Meeting))).Return(true);

            IMeetingService meetingService = new MeetingService(noteRepositoryMock);

            var result = meetingService.Update(model);

            Assert.IsTrue(result);
            noteRepositoryMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void ShouldReturnFalseIfNotUpdated()
        {
            var model = new MeetingModel()
            {
                Id = 1,
                Title = "title",
                DateTime = DateTime.UtcNow,
                DueDateTime = DateTime.UtcNow.AddDays(1),
                Place = "meeting place",
            };

            var noteRepositoryMock = MockRepository.GenerateMock<INoteRepository>();
            noteRepositoryMock.Expect(repo => repo.Update(Arg<Note>.Matches(x => x.Id == model.Id))).Return(false);

            IMeetingService meetingService = new MeetingService(noteRepositoryMock);

            var result = meetingService.Update(model);

            Assert.IsFalse(result);
            noteRepositoryMock.VerifyAllExpectations();
        }
    }
}
