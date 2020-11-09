using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Weekly_PlannerDataLayer;
using Microsoft.EntityFrameworkCore;

namespace Weekly_Planner_BusinessLayer
{
    public class CRUDManagerNotes
    {
        public WeekDay currentDay { get; set; }

        public Note currentNote { get; set; }

        public NotesColourCategory currentColour { get; set; }
        public void setSelectedNote(object selectedItem)
        {
            currentNote = (Note)selectedItem;
            setSelectedColour(); 
            setSelectedDay();
            
        }
        public void setSelectedDay(object selectedItem)
        {
            try
            {currentDay = (WeekDay)selectedItem;}
            catch
            { setSelectedDay();}
        }

        public void setSelectedDay() 
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                currentDay = db.Notes.Where(a => a.NoteId == currentNote.NoteId)
                    .Include(o => o.WeekDays)
                    .Select(s => s.WeekDays)
                    .FirstOrDefault(); 
            }
        }

        public void setSelectedColour(object selectedItem)
        {
            try
            {currentColour = (NotesColourCategory)selectedItem;}
            catch
            {setSelectedColour();}
        }

        public void setSelectedColour()  
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                currentColour = db.Notes.Where(a => a.NoteId == currentNote.NoteId)
                    .Include(o => o.NotesColourCategorys)
                    .Select(o => o.NotesColourCategorys)
                    .FirstOrDefault(); 
            }
        }

        public List<WeekDay> ListOfDays()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                return db.WeekDays.ToList();
            }
        }

        public List<String> ListOfDaysString()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                List<String> days = new List<string>();

                foreach (var item in db.WeekDays.ToList())
                {
                    days.Add(item.Day);
                }

                return days;
            }
        }

        public List<String> ListOfColourStrings()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                List<String> colours = new List<string>();

                foreach (var item in db.NotesColourCategories.ToList())
                {
                    colours.Add(item.Colour);
                }

                return colours;
            }
        }

        public List<NotesColourCategory> ListOfColours()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                return db.NotesColourCategories.ToList();
            }
        }

        public List<Note> ListOfNotes(object selectedItem)
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                try
                {
                    var item = (WeekDay)selectedItem;
                    return db.Notes.Where(o => o.WeekDayId == item.WeekDayId).Include(s => s.WeekDays).Include(o=> o.NotesColourCategorys).ToList();
                }
                catch //if its not a weekday object it will do try convert it to a coloured one
                {
                    var item = (NotesColourCategory)selectedItem;
                    return db.Notes.Where(o => o.NotesColourCategoryId == item.NotesColourCategoryId).Include(s => s.NotesColourCategorys).ToList();
                }
            }
        }

        public List<Note> ListOfNotes()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                return db.Notes.Include(o=> o.NotesColourCategorys).ToList();
            }
        }

        public void CreateNote(string colour, string day, string title, string content)
        {
            using(var db = new WeeklyPlannerDBContext())
            {
                if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");
                if (content.Count() == 0) throw new ArgumentException("The Note's content cannot be empty!");

                var isCreatedQ = db.Notes.Where(a => a.Title == title.Trim()).FirstOrDefault();
                if (isCreatedQ != null) throw new ArgumentException("A Note with the same name already exists!");

                var getDay = db.WeekDays.Where(w => w.Day == day.Trim()).FirstOrDefault();
                var getColour = db.NotesColourCategories.Where(p => p.Colour == colour.Trim()).FirstOrDefault();
                Note newNote = new Note()
                {
                    Title = title.Trim(),
                    Content = content.Trim(),
                    NotesColourCategorys = getColour,
                    WeekDays = getDay
                };

                db.Notes.Add(newNote);
                db.SaveChanges();
            }
        }

        public void EditNote(int id, string title, string content, string day, string colour)
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");

                if (content.Count() == 0) throw new ArgumentException("The Note's content cannot be empty!");

                var isCreatedQ = db.Notes.Where(a => a.Title == title.Trim() & a.NoteId != id ).FirstOrDefault();
                if (isCreatedQ != null) throw new ArgumentException("A Note with the same name already exists!");
                
                var getDay = db.WeekDays.Where(w => w.Day == day.Trim()).FirstOrDefault();
                var getColour = db.NotesColourCategories.Where(p => p.Colour == colour.Trim()).FirstOrDefault();

                var getNote = db.Notes.Where(w => w.NoteId == id).FirstOrDefault();
                getNote.Title = title.Trim();
                getNote.Content = content.Trim();
                getNote.WeekDays = getDay;
                getNote.NotesColourCategorys = getColour;
                db.SaveChanges();

            }
        }

        public void DeleteNote(int id)
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getNote = db.Notes.Where(w => w.NoteId == id).FirstOrDefault();
                db.Notes.RemoveRange(getNote);
                db.SaveChanges();
            }
        }
    }
}
