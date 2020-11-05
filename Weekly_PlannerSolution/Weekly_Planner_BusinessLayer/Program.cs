using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Weekly_PlannerDataLayer;

namespace Weekly_Planner_BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new WeeklyPlannerDBContext())
            {

                //NotesColourCategory newColour = new NotesColourCategory()
                //{
                //    Colour = "Green"
                //};

                //db.NotesColourCategories.Add(newColour);
                //db.SaveChanges();

                //var newQuery =
                //    from c in db.NotesColourCategories
                //    select c;


                //foreach (var item in newQuery)
                //{
                //    Console.WriteLine($"{item.NotesColourCategoryId} - {item.Colour}");
                //}


                //NotesColourCategory newColour = new NotesColourCategory()
                //{
                //    Colour = "Pink"
                //};

                //var colourQuery = db.NotesColourCategories.Where(c => c.Colour == "Red").FirstOrDefault();


                //WeekDay newDay = new WeekDay()
                //{
                //    Day = "Friday"
                //};

                //var newDay = db.WeekDays.Where(w => w.Day == "Thursday").FirstOrDefault();

                //Activity newActivity = new Activity()
                //{
                //    Name = "Room Clean up",
                //    Content = "Need to organise my room so I can study better ",
                //    WeekDays = newDay
                //};

                //Note newNote = new Note()
                //{
                //    Title = "This is my third Note",
                //    Content = "last bit of data to add today to db, so sleepy!",
                //    WeekDays = newDay,
                //    NotesColourCategorys = colourQuery
                //};

                ////db.NotesColourCategories.Add(newColour);
                //db.WeekDays.Add(newDay);
                //db.Activities.Add(newActivity);
                //db.Notes.Add(newNote);

                //var removeAct = db.Activities.Where(w => w.Name == "Testing").FirstOrDefault();
                //db.Activities.RemoveRange(removeAct);
                //db.SaveChanges();


            }
        }
    }
}
