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

        public void setSelectedNote(object selectedItem)
        {
            currentNote = (Note)selectedItem;
        }
        public void setSelectedDay(object selectedItem)
        {
            using(var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.Notes.Where(a => a.NoteId == currentNote.NoteId).Include(o => o.WeekDays).FirstOrDefault();
                currentDay = getDay.WeekDays;
            }
            
        }

        public void CreateNote(string colour, string day, string title, string content)
        {
            using(var db = new WeeklyPlannerDBContext())
            {
                if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");

                if (content.Count() == 0) throw new ArgumentException("The Note's content cannot be empty!");

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
