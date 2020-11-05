using System;
using System.Linq;
using Weekly_PlannerDataLayer;

namespace Weekly_Planner_BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            

            using(var db = new WeeklyPlannerDBContext())
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

                //Activity newActivity = new Activity()
                //{
                //    Name = "Project meeting at 6pm",
                //    Content = "Need to call colleague Alex M , Robert, Jacob and Oliver T about the blogging project",
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
                //db.SaveChanges();


            }
        }
    }
}
