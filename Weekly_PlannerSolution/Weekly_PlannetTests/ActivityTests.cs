using NUnit.Framework;
using Weekly_Planner_BusinessLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer;
using System;

namespace Weekly_PlannetTests
{
    public class Tests
    {
        CRUDManagerActivity _crudManager = new CRUDManagerActivity();


        [SetUp]
        public void Setup()
        {
            using (var db = new WeeklyPlannerDBContext())
            {

                var selectActivity =
                    from a in db.Activities
                    where a.Name == "Test"
                    select a;

                db.Activities.RemoveRange(selectActivity);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new WeeklyPlannerDBContext())
            {

                var selectActivity =
                    from a in db.Activities
                    where a.Name == "Test"
                    select a;

                db.Activities.RemoveRange(selectActivity);
                db.SaveChanges();
            }

        }

        [Test]
        public void WhenCreatingAnActivity_TheCountIncreasesByOne()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var count = db.Activities.Count();
                _crudManager.CreateActivity("Test", "I have to test the create activity method", "Monday");
                var newCount = db.Activities.Count();
                Assert.AreEqual(count + 1, newCount);
         
            }
        }

        [Test]
        public void WhenCreatingAnActivity_TheInformationStoredIsCorrect()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Tuesday").FirstOrDefault();

                Activity newActivity = new Activity()
                {
                    Name = "Test",
                    Content = "Have to check if content and title are correct",
                    WeekDays = getDay
                };
                db.Activities.Add(newActivity);
                db.SaveChanges();

                var getActivity = db.Activities.Where(a => a.Name == "Test").Select(s => new { s.Name, s.Content }).FirstOrDefault();
                Assert.AreEqual(("Test", "Have to check if content and title are correct"), (getActivity.Name, getActivity.Content));

            }
        }

        [Test]
        public void WhenCreatingADuplicateActivity_AnExceptionIsThrown()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Tuesday").FirstOrDefault();

                Activity newActivity = new Activity()
                {
                    Name = "Test",
                    Content = "Have to check if content and title are correct",
                    WeekDays = getDay
                };
                db.Activities.Add(newActivity);
                db.SaveChanges();

                var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateActivity("Test", "This is a duplicate activity tutut", "Tuesday"));
                Assert.AreEqual("An activity with the same name already exists!", ex.Message);

            }
        }

        [Test]
        public void CreatingAnActivityWithAnEmptyTitle_ThrowsAnException()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateActivity("", "I have to test the create activity method", "Monday"));
                Assert.AreEqual("Title cannot be empty!", ex.Message);

            }
        }

        [Test]
        public void CreatingAnActivityWithAnEmptyContent_ThrowsAnException()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateActivity("Test", "", "Monday"));
                Assert.AreEqual("The activity's content cannot be empty!", ex.Message);

            }
        }


        [Test]
        public void WhenEditingAnActivity_TheNewInformationOverridesTheOld()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Wednesday").FirstOrDefault();
                Activity newActivity = new Activity()
                {
                    Name = "Testing",
                    Content = "Have to check if content and title and day can be changed",
                    WeekDays = getDay
                };
                db.Activities.Add(newActivity);
                db.SaveChanges();

                var getActivity = db.Activities.Where(a => a.Name == "Testing").Select(s => new { s.ActivityId }).FirstOrDefault();
                _crudManager.EditActivity(getActivity.ActivityId,"Test", "The content and title and day have changed","Tuesday");

                var updatedActivity = db.Activities.Where(a => a.ActivityId == getActivity.ActivityId).Select(s => new { s.Name, s.Content, s.WeekDays.Day }).FirstOrDefault();


                Assert.AreEqual("Test", updatedActivity.Name);
                Assert.AreEqual("The content and title and day have changed", updatedActivity.Content);
                Assert.AreEqual("Tuesday", updatedActivity.Day);


            }
        }

        [Test]
        public void WhenEditingAnActivity_IfTitleIsEmptyAnExceptionIsThrown()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Wednesday").FirstOrDefault();
                Activity newActivity = new Activity()
                {
                    Name = "Test",
                    Content = "Have to check if content and title and day can be changed",
                    WeekDays = getDay
                };
                db.Activities.Add(newActivity);
                db.SaveChanges();

                var getActivity = db.Activities.Where(a => a.Name == "Test").Select(s => new { s.ActivityId }).FirstOrDefault();
          
                var ex = Assert.Throws<ArgumentException>(() => _crudManager.EditActivity(getActivity.ActivityId, "", "The content and title and day have changed", "Tuesday"));
                Assert.AreEqual("Title cannot be empty!", ex.Message);


            }
        }

        [Test]
        public void WhenEditingAnActivity_IfContentIsEmptyAnExceptionIsThrown()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Wednesday").FirstOrDefault();
                Activity newActivity = new Activity()
                {
                    Name = "Test",
                    Content = "Have to check if content and title and day can be changed",
                    WeekDays = getDay
                };
                db.Activities.Add(newActivity);
                db.SaveChanges();

                var getActivity = db.Activities.Where(a => a.Name == "Test").Select(s => new { s.ActivityId }).FirstOrDefault();

                var ex = Assert.Throws<ArgumentException>(() => _crudManager.EditActivity(getActivity.ActivityId, "Testing", "", "Tuesday"));
                Assert.AreEqual("The activity's content cannot be empty!", ex.Message);


            }
        }

        [Test]
        public void WhenDeletingAnActivity_TheActivityIsRemovedFromDB()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Tuesday").FirstOrDefault();

                Activity newActivity = new Activity()
                {
                    Name = "Test",
                    Content = "Have to check if content and title are correct",
                    WeekDays = getDay
                };
                db.Activities.Add(newActivity);
                db.SaveChanges();

                var getActivity = db.Activities.Where(a => a.Name == "Test").Select(s => new { s.ActivityId }).FirstOrDefault();
                _crudManager.DeleteActivity(getActivity.ActivityId);

                var deletedActivity = db.Activities.Where(a => a.ActivityId == getActivity.ActivityId).FirstOrDefault();

                Assert.IsNull(deletedActivity);

            }
        }

    }
}