﻿using NUnit.Framework;
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


        [Test]
        public void WhenANoteIsCreated_TheCountIncreases()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var count = db.Notes.Count();
                _crudManager.CreateNote("Red", "Monday", "Test", "This is my first note for the day");
                var newCount = db.Notes.Count();

                Assert.AreEqual(count + 1, newCount);

            }
        }

        [Test]
        public void WhenANoteIsCreated_TheContentIsCorrect()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Monday").FirstOrDefault();
                var getColour = db.NotesColourCategories.Where(p => p.Colour == "Red").FirstOrDefault();

                Note newNote = new Note()
                {
                    Title = "Test",
                    Content = "This is my second note for the day",
                    NotesColourCategorys = getColour,
                    WeekDays = getDay
                };

                db.Notes.Add(newNote);
                db.SaveChanges();

                var getNote = db.Notes.Where(w => w.Title == "Test").FirstOrDefault();

                Assert.AreEqual("Test", getNote.Title);
                Assert.AreEqual("This is my second note for the day", getNote.Content);
                Assert.AreEqual("Monday", getNote.WeekDays.Day);
                Assert.AreEqual("Red", getNote.NotesColourCategorys.Colour);
            }
        }

        [Test]
        public void WhenANoteWithoutATitleIsCreated_AnExceptionIsThrown()
        {
            var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateNote("Red", "Monday", "", "This is my first note for the day"));
            Assert.AreEqual("Title cannot be empty!", ex.Message);
        }

        [Test]
        public void WhenANoteWithoutAContentIsCreated_AnExceptionIsThrown()
        {
            var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateNote("Red", "Monday", "Test", ""));
            Assert.AreEqual("The Note's content cannot be empty!", ex.Message);
        }

        [Test]
        public void WhenANoteIsEdited_TheContentIsCorrect()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Monday").FirstOrDefault();
                var getColour = db.NotesColourCategories.Where(p => p.Colour == "Red").FirstOrDefault();

                Note newNote = new Note()
                {
                    Title = "Testing",
                    Content = "This is my second note for the day",
                    NotesColourCategorys = getColour,
                    WeekDays = getDay
                };

                db.Notes.Add(newNote);
                db.SaveChanges();

                var getNote = db.Notes.Where(w => w.Title == "Testing").FirstOrDefault();

                _crudManager.EditNote(getNote.NoteId, "Test", "This is my edited content", "Wednesday", "Green");

                var editedNote = db.Notes.Where(p => p.NoteId == getNote.NoteId).Include(o=> o.WeekDays).Include(p=> p.NotesColourCategorys)
                    .Select(s=> new { s.Title, s.Content, s.WeekDays.Day, s.NotesColourCategorys.Colour}).FirstOrDefault();

                Assert.AreEqual("Test", editedNote.Title);
                Assert.AreEqual("This is my edited content", editedNote.Content);
                Assert.AreEqual("Wednesday", editedNote.Day);
                Assert.AreEqual("Green", editedNote.Colour);
            }
        }

        [Test]
        public void WhenANoteIsEdited_WithEmptyTitleAnExceptionIsThrown()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Monday").FirstOrDefault();
                var getColour = db.NotesColourCategories.Where(p => p.Colour == "Red").FirstOrDefault();

                Note newNote = new Note()
                {
                    Title = "Test",
                    Content = "This is my second note for the day",
                    NotesColourCategorys = getColour,
                    WeekDays = getDay
                };

                db.Notes.Add(newNote);
                db.SaveChanges();

                var getNote = db.Notes.Where(w => w.Title == "Test").FirstOrDefault();

                var ex = Assert.Throws<ArgumentException>(() => _crudManager.EditNote(getNote.NoteId, "", "This is my edited content", "Wednesday", "Green"));
                Assert.AreEqual("Title cannot be empty!", ex.Message);
            }
        }

        [Test]
        public void WhenANoteIsEdited_WithEmptyContentAnExceptionIsThrown()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Monday").FirstOrDefault();
                var getColour = db.NotesColourCategories.Where(p => p.Colour == "Red").FirstOrDefault();

                Note newNote = new Note()
                {
                    Title = "Test",
                    Content = "This is my second note for the day",
                    NotesColourCategorys = getColour,
                    WeekDays = getDay
                };

                db.Notes.Add(newNote);
                db.SaveChanges();

                var getNote = db.Notes.Where(w => w.Title == "Test").FirstOrDefault();

                var ex = Assert.Throws<ArgumentException>(() => _crudManager.EditNote(getNote.NoteId, "Testing", "", "Wednesday", "Green"));
                Assert.AreEqual("The Note's content cannot be empty!", ex.Message);
            }
        }
    }
}
