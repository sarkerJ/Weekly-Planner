using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Weekly_PlannerDataLayer;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer.Services;

namespace Weekly_Planner_BusinessLayer
{
    public class CRUDManagerActivity
    {
        private ActivityService _activityService;
        private DayService _dayService;

        public CRUDManagerActivity()
        {
            WeeklyPlannerDBContext db = new WeeklyPlannerDBContext();
            _activityService = new ActivityService(db);
            _dayService = new DayService(db);
        }

        public Activity currentActivity { get; set; } 
        public WeekDay currentDay { get; set; }

        //Setting methods
        public void setSelectedActivity(object selectedItem)
        {
            currentActivity = (Activity)selectedItem;
            setSelectedDay();
        }

        public void setSelectedDay(object selectedItem) => currentDay = (WeekDay)selectedItem;

        public void setSelectedDay(string day) => currentDay = _dayService.GetDayByString(day.Trim());
        
        public void setSelectedDay() => currentDay = _dayService.GetDayByActivity(currentActivity);
        
        //List Methods
        public List<Activity> ListOfActivities(string day) =>  _activityService.GetListOfActivitiesByDay(day.Trim());

        public List<WeekDay> ListOfDays() => _dayService.GetListOfDays();

        public List<String> ListOfDaysString() => _dayService.GetListOfDaysString();
        

        public void checkInput(string title, string content, string day, int? id = null )
        {
            
            if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");
            if (content.Count() == 0) throw new ArgumentException("The activity's content cannot be empty!");

            var count = _activityService.GetActivitiesCountByDay(day.Trim());
            if (count > 15) throw new Exception($"Cannot create any more activities for {day.Trim()}");

            if (id == null)
            {
                var isCreatedQ = _activityService.GetActivityByName(title);
                if (isCreatedQ != null) throw new ArgumentException("An activity with the same name already exists!");
            }
            else
            {
                var isCreatedQ = _activityService.GetActivityByNameAndId(title, id);
                if (isCreatedQ != null) throw new ArgumentException("An activity with the same name already exists!");
            }
        }

        //Create an Activity
        public void CreateActivity(string title, string content, string day)
        {
            checkInput(title.Trim(), content.Trim(), day.Trim());
            var getDay = _dayService.GetDayByString(day.Trim());
            Activity newActivity = new Activity()
            {
                Name = title,
                Content = content,
                WeekDays = getDay
            };
            _activityService.AddActivity(newActivity);
            _activityService.UpdateActivity();
        }

        //Modifying an Activity
        public void EditActivity(int activityID, string title, string content, string day)
        {
            checkInput(title, content, day, activityID);

            var currentActivity = _activityService.GetActivityById(activityID);
            var getDay = _dayService.GetDayByString(day.Trim());

            currentActivity.Name = title.Trim();
            currentActivity.Content = content.Trim();
            currentActivity.WeekDays = getDay;
            _activityService.UpdateActivity();
        }

        //Deleting an Activity
        public void DeleteActivity(int activityID)
        {
            var currentActivity = _activityService.GetActivityById(activityID);
            _activityService.DeleteActivity(currentActivity);
            _activityService.UpdateActivity();
             currentActivity = null; //used to cause exception if you are trying to delete something again when nothing is selected
        }

    }
}
