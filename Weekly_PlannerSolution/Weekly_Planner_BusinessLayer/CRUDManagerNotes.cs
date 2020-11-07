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

        
    }
}
