using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer;
using System;
using NUnit.Framework.Constraints;
using Weekly_PlannerDataLayer.Services;
using System.Collections.Generic;

namespace Weekly_PlannetTests
{
    class FakeDBActivityTesting
    {
        private ActivityService _service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<WeeklyPlannerDBContext>()
                .UseInMemoryDatabase(databaseName: "Example_DB")
                .Options;
            var context = new WeeklyPlannerDBContext(options);
            _service = new ActivityService(context);

            List<Activity> listActivities = new List<Activity>()
            {
                new Activity(){Name = "Test1", Content = "First Content", WeekDays = new WeekDay() { Day ="Monday"}},
                new Activity(){Name = "Test2", Content = "Second Content", WeekDays = new WeekDay() { Day ="Tuesday"}},
                new Activity(){Name = "Test3", Content = "Third Content", WeekDays = new WeekDay() { Day ="Wednesday"}},
                new Activity(){Name = "Test4", Content = "Fourth Content", WeekDays = new WeekDay() { Day ="Thursday"}},
                new Activity(){Name = "Test5", Content = "Fifth Content", WeekDays = new WeekDay() { Day ="Friday"}},
            };
    
            foreach(var item in listActivities) _service.AddActivity(item);
            _service.UpdateActivity();
            
        }

        [Category("FakeDB_ActivityService_Test")]
        [TestCase("Test1", "Test1", "First Content", "Monday", 1)]
        [TestCase("Test2", "Test2", "Second Content", "Tuesday", 2)]
        [TestCase("Test3", "Test3", "Third Content", "Wednesday", 3)]
        [TestCase("Test4", "Test4", "Fourth Content", "Thursday", 4)]
        [TestCase("Test5", "Test5", "Fifth Content", "Friday", 5)]
        public void GivenAName_Returns_CorrectActivity_Information(string name, string expectedName, string content, string day, int id)
        {
            var activity = _service.GetActivityByName(name);

            Assert.That(activity.Name, Is.EqualTo(expectedName));
            Assert.That(activity.Content, Is.EqualTo(content));
            Assert.That(activity.WeekDays.Day, Is.EqualTo(day));
            Assert.AreEqual(id, activity.WeekDayId);
        }

        [Category("FakeDB_ActivityService_Test")]
        [TestCase("Test1", "First Content", "Monday", 1)]
        [TestCase("Test2", "Second Content", "Tuesday", 2)]
        public void GivenAnId_Returns_CorrectActivity_Information(string expectedName, string content, string day, int id)
        {
            var activity = _service.GetActivityById(id);

            Assert.That(activity.Name, Is.EqualTo(expectedName));
            Assert.That(activity.Content, Is.EqualTo(content));
            Assert.That(activity.WeekDays.Day, Is.EqualTo(day));
        }


        [Test]
        [Category("FakeDB_ActivityService_Test")]
        public void Adding_ANew_Activity_IncreaseCountBy_One()
        {
            Activity newActivity = new Activity() { Name = "Test6", Content = "Sixth Content", WeekDays = new WeekDay() { Day = "Monday" } };
            _service.AddActivity(newActivity);
            _service.UpdateActivity();
            Assert.That(_service.GetActivitiesCountByDay("Monday"), Is.EqualTo(2));

        }

        [Test]
        [Category("FakeDB_ActivityService_Test")]
        public void DeleteActivity_RemovesActivity_FromDatabase()
        {
            Activity newActivity = new Activity() { Name = "Test7", Content = "Seventh Content", WeekDays = new WeekDay() { Day = "Friday" } };
            _service.AddActivity(newActivity);
            _service.UpdateActivity();

            _service.DeleteActivity(newActivity);
            _service.UpdateActivity();

            Assert.That( _service.GetActivityByName("Test7"), Is.Null);
        }

        [Test]
        [Category("FakeDB_ActivityService_Test")]
        public void EditActivity_Updates_ActivityInformation()
        {
            Activity newActivity = new Activity() { Name = "Test7", Content = "Seventh Content", WeekDays = new WeekDay() { Day = "Friday" } };
            _service.AddActivity(newActivity);
            _service.UpdateActivity();

            var currentActivity = _service.GetActivityByName("Test7");
            currentActivity.Name = "Test71";
            currentActivity.Content = "Seventhhh Content";
            currentActivity.WeekDays = new WeekDay() { Day = "Monday" };
            _service.UpdateActivity();

            var updatedActivity = _service.GetActivityById(currentActivity.ActivityId);
            Assert.That(updatedActivity.Name, Is.EqualTo("Test71"));
            Assert.That(updatedActivity.Content, Is.EqualTo("Seventhhh Content"));
            Assert.That(updatedActivity.WeekDays.Day, Is.EqualTo("Monday"));

        }

    }
}
