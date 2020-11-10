using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Weekly_PlannerDataLayer;
using Microsoft.EntityFrameworkCore;

namespace Weekly_Planner_BusinessLayer
{
    public class CRUDManagerActivity
    {

        public Activity currentActivity { get; set; } 
        public WeekDay currentDay { get; set; }

        //Setting methods
        public void setSelectedActivity(object selectedItem)
        {
            currentActivity = (Activity)selectedItem;
            setSelectedDay();
        }

        public void setSelectedDay(object selectedItem)
        {
                currentDay = (WeekDay)selectedItem;   
        }

        public void setSelectedDay(string day)
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                currentDay = db.WeekDays.Where(w => w.Day == day.Trim()).FirstOrDefault();
            }
        }
        public void setSelectedDay()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var getDay = db.Activities.Where(a => a.ActivityId == currentActivity.ActivityId).Include(o => o.WeekDays).FirstOrDefault();
                currentDay = getDay.WeekDays;
            }
        }
        
        //List Methods
        public List<Activity> ListOfActivities(string day)
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                return db.Activities.Include(o=> o.WeekDays).Where(w => w.WeekDays.Day == day.Trim()).ToList();                
            }
        }
        public List<WeekDay> ListOfDays()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                return db.WeekDays.ToList();
            }
        }
        public List<String> ListOfDaysString() //Used for drop down menu for editing an activity
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                List<String> days = new List<string>();

                foreach(var item in db.WeekDays.ToList())
                {
                    days.Add(item.Day);
                }

                return days;
            }
        }

        //Setting Capacity Limit of activities for each day
        public void maxActivity()
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                var listOfDays = ListOfDays();

                foreach(var item in listOfDays)
                {
                    var count = ListOfActivities(item.Day).Count();

                    if (count > 15) throw new Exception($"Cannot create any more activities for {item.Day}");
                }
            }
        }

        //Create an Activity
        public void CreateActivity(string title, string content, string day)
        {
            if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");
            if (content.Count() == 0) throw new ArgumentException("The activity's content cannot be empty!");
            maxActivity();

            using(var db = new WeeklyPlannerDBContext())
            {
                var isCreatedQ = db.Activities.Where(a => a.Name == title.Trim()).FirstOrDefault();
                if (isCreatedQ != null) throw new ArgumentException("An activity with the same name already exists!");


                var getDay = db.WeekDays.Where(w => w.Day == day.Trim()).FirstOrDefault();

                Activity newActivity = new Activity()
                {
                    Name = title,
                    Content = content,
                    WeekDays = getDay
                };

                db.Activities.Add(newActivity);
                db.SaveChanges();
            }
        }

        //Modifying an Activity
        public void EditActivity(int activityID, string title, string content, string day)
        {
            if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");

            if (content.Count() == 0) throw new ArgumentException("The activity's content cannot be empty!");
            
            using (var db = new WeeklyPlannerDBContext())
            {
                var currentActivity = db.Activities.Where(a => a.ActivityId == activityID).FirstOrDefault();

                var getDay = db.WeekDays.Where(w => w.Day == day.Trim()).FirstOrDefault();
                currentActivity.Name = title.Trim();
                currentActivity.Content = content.Trim();
                currentActivity.WeekDays = getDay;
                
                db.SaveChanges();
            }
        }

        //Deleting an Activity
        public void DeleteActivity(int activityID)
        {
            using(var db = new WeeklyPlannerDBContext())
            {
                var currentActivity = db.Activities.Where(a => a.ActivityId == activityID).FirstOrDefault();
                db.Activities.RemoveRange(currentActivity);
                db.SaveChanges();
            }
            currentActivity = null; //used to cause exception if you are trying to delete something again when nothing is selected
        }

    }
}
