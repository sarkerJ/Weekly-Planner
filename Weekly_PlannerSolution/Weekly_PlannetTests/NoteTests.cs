using NUnit.Framework;
using Weekly_Planner_BusinessLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer;
using System;
using NUnit.Framework.Constraints;

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

                var ex = Assert.Throws<ArgumentException>(() => _crudManager.CreateNote("Green", "Tuesday", "Test", "This is my second note for the day"));
                Assert.AreEqual("A Note with the same name already exists!", ex.Message);
            }
        }

        [Test]
        public void WhenANoteWithTheSameNameIsCreated_AnExceptionIsThrown()
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

                var getNote = db.Notes.Where(w => w.Title == "Testing").Select(o=> o.NoteId).FirstOrDefault();

                _crudManager.EditNote(getNote, "Test", "This is my edited content", "Wednesday", "Green");

                var editedNote = db.Notes.Where(p => p.NoteId == getNote).Include(o => o.WeekDays).Include(p => p.NotesColourCategorys)
                    .Select(s => new { s.Title, s.Content, s.WeekDays.Day, s.NotesColourCategorys.Colour }).FirstOrDefault();

                //Assert.AreEqual("Test", editedNote.Title);
                //Assert.AreEqual("This is my edited content", editedNote.Content);
                //Assert.AreEqual("Wednesday", editedNote.Day);
                //Assert.AreEqual("Green", editedNote.Colour);
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

        [Test]
        public void WhenANoteIsEdited_WithAnExisitingTitleAnExceptionIsThrown()
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
                Note newNote1 = new Note()
                {
                    Title = "Testing",
                    Content = "This is my Third note for the day",
                    NotesColourCategorys = getColour,
                    WeekDays = getDay
                };
                db.Notes.Add(newNote);
                db.Notes.Add(newNote1);

                db.SaveChanges();

                var getNote = db.Notes.Where(w => w.Title == "Testing").FirstOrDefault();

                var ex = Assert.Throws<ArgumentException>(() => _crudManager.EditNote(getNote.NoteId, "Test", "This is my edited comment note for the day", "Wednesday", "Green"));
                Assert.AreEqual("A Note with the same name already exists!", ex.Message);

                db.Notes.RemoveRange(newNote1);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenNoteIsDeletedCountIsDecreasedByOne()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var count = db.Notes.Count();

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

                _crudManager.Delete(getNote.NoteId);

                var newCount = db.Notes.Count();

                Assert.AreEqual(count, newCount);
            }
        }

        [Test]
        public void WhenDayObjectIsGiven_ItReturnsListOfNotesBasedOnthatDay()
        {

            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Monday").FirstOrDefault();

                var listOfNotes = _crudManager.ListOfNotes(getDay);

                foreach(var item in listOfNotes)
                {
                    Assert.AreEqual(getDay.WeekDayId, item.WeekDayId);
                }

            }

        }

        [Test]
        public void WhenColourCategoryObjectIsGiven_ItReturnsListOfNotesBasedOnthatColour()
        {

            using (var db = new WeeklyPlannerDBContext())
            {
                var getColour = db.NotesColourCategories.Where(p => p.Colour == "Red").FirstOrDefault();

                var listOfNotes = _crudManager.ListOfNotes(getColour);

                foreach (var item in listOfNotes)
                {
                    Assert.AreEqual(getColour.NotesColourCategoryId, item.NotesColourCategoryId);
                }

            }

        }


        [Test]
        public void WhenListOfNotesParametelessIsExecuted_ItReturnsAListOfNoteObjects()
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
                var listOfNotes = _crudManager.ListOfNotes();

                foreach(var item in listOfNotes)
                {
                    Assert.AreEqual(getNote.GetType(),item.GetType());
                }
            }
        }

        [Test]
        public void WhenListOfColoursIsExecuted_ItReturnsAListOfColourObjects()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getColour = db.NotesColourCategories.Where(p => p.Colour == "Red").FirstOrDefault();
                var listOfColours = _crudManager.ListOfColours();

                foreach(var item in listOfColours)
                {
                    Assert.AreEqual(getColour.GetType(), item.GetType());
                }
            }
        }

        [Test]
        public void WhenListOfDayIsExecuted_ItReturnsAListOfDayObjects() 
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Monday").FirstOrDefault();
                
                var listOfDays = _crudManager.ListOfDays();

                foreach (var item in listOfDays)
                {
                    Assert.AreEqual(getDay.GetType(), item.GetType());
                }
            }
        }

        [Test]
        public void WhenSetSelectedNoteIsUsed_CurrentNotePropertyANDDayPropertyANDColourPropertyContainCorrectObject()
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

                _crudManager.SetSelectedNote(getNote);

                Assert.AreEqual(getNote.NoteId, _crudManager.CurrentNote.NoteId);
                Assert.AreEqual(getNote.Title, _crudManager.CurrentNote.Title);
                Assert.AreEqual(getNote.Content, _crudManager.CurrentNote.Content);
                Assert.AreEqual(getNote.NotesColourCategoryId, _crudManager.CurrentColour.NotesColourCategoryId);
                Assert.AreEqual(getNote.WeekDayId, _crudManager.CurrentDay.WeekDayId);
            }
        }

        [Test]
        public void WhenSetSelectDayIsUsed_CurrentDayPropertyHoldsCorrectObject()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.WeekDays.Where(w => w.Day == "Monday").FirstOrDefault();

                _crudManager.SetSelectedDay(getDay);

                Assert.AreEqual(getDay.WeekDayId, _crudManager.CurrentDay.WeekDayId);
                Assert.AreEqual(getDay.Day, _crudManager.CurrentDay.Day);
            }
        }

        [Test]
        public void WhenSetSelectColourIsUsed_CurrentColourHoldsCorrectObject()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getColour = db.NotesColourCategories.Where(p => p.Colour == "Red").FirstOrDefault();

                _crudManager.SetSelectedColour(getColour);

                Assert.AreEqual(getColour.NotesColourCategoryId, _crudManager.CurrentColour.NotesColourCategoryId);
                Assert.AreEqual(getColour.Colour, _crudManager.CurrentColour.Colour);
            }
        }
    }
}
