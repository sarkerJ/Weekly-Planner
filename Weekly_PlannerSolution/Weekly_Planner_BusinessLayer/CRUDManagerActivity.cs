using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Weekly_PlannerDataLayer;

namespace Weekly_Planner_BusinessLayer
{
    public class CRUDManagerActivity
    {

        public Activity currentActivity { get; set; }

        public void setSelectedActivity(object selectedItem)
        {
            currentActivity = (Activity)selectedItem;
        }

        public List<Activity> ListOfActivities(string day)
        {
            using (var db = new WeeklyPlannerDBContext())
            {
                return db.Activities.Where(w => w.WeekDays.Day == day.Trim()).ToList();                
            }
        }


        //Create an Activity
        public void CreateActivity(string title, string content, string day)
        {
            if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");

            if (content.Count() == 0) throw new ArgumentException("The activity's content cannot be empty!");

            using(var db = new WeeklyPlannerDBContext())
            {
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
        }

    }
}
