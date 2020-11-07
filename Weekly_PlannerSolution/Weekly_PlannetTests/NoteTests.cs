using NUnit.Framework;
using Weekly_Planner_BusinessLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer;
using System;

namespace Weekly_PlannetTests
{
    class NoteTests
    {
        CRUDManagerNotes _crudManager = new CRUDManagerNotes();

        [SetUp]
        public void Setup()
        {
            using (var db = new WeeklyPlannerDBContext())
            {

                var selectNote =
                    from n in db.Notes
                    where n.Title == "Test"
                    select n;

                db.Notes.RemoveRange(selectNote);
                db.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new WeeklyPlannerDBContext())
            {

                var selectNote =
                    from n in db.Notes
                    where n.Title == "Test"
                    select n;

                db.Notes.RemoveRange(selectNote);
                db.SaveChanges();
            }

        }
    }
}
