using NUnit.Framework;
using Weekly_Planner_BusinessLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer;



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

    }
}