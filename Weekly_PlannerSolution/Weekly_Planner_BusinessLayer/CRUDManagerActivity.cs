using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Weekly_PlannerDataLayer;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer.Services;

namespace Weekly_Planner_BusinessLayer
{
    public class CRUDManagerActivity : CRUDManager
    {
        private readonly WeeklyPlannerDBContext _dbContext;
        
        private readonly IActivityService _activityService;
        private readonly IDayService _dayService;

        public CRUDManagerActivity()
        {
            _dbContext = new WeeklyPlannerDBContext();
            _activityService = new ActivityService(_dbContext);
            _dayService = new DayService(_dbContext);
        }

        public CRUDManagerActivity(IActivityService activityService, IDayService dayService)
        {
            _activityService = activityService;
            _dayService = dayService;
        }

        public Activity CurrentActivity { get; set; } 
        public WeekDay CurrentDay { get; set; }

        //Setting methods
        public void SetSelectedActivity(object selectedItem)
        {
            CurrentActivity = (Activity)selectedItem;
            SetSelectedDay();
        }

        public void SetSelectedDay(object selectedItem) => CurrentDay = (WeekDay)selectedItem;

        public void SetSelectedDay(string day) => CurrentDay = _dayService.GetDayByString(day.Trim());
        
        public override void SetSelectedDay() => CurrentDay = _dayService.GetDayByActivity(CurrentActivity);
        
        //List Methods
        public List<Activity> ListOfActivities(string day) =>  _activityService.GetListOfActivitiesByDay(day.Trim());

        public override List<WeekDay> ListOfDays() => _dayService.GetListOfDays();

        public override List<String> ListOfDaysString() => _dayService.GetListOfDaysString();
        
        public void IsMaxReached(string day)
        {
            var count = _activityService.GetActivitiesCountByDay(day.Trim());
            if (count > 15) throw new Exception($"Cannot create any more activities for {day.Trim()}");
        }

        public override void CheckInput(string title, string content, string day, int? id = null )
        {
            
            if (title.Count() == 0) throw new ArgumentException("Title cannot be empty!");
            if (content.Count() == 0) throw new ArgumentException("The activity's content cannot be empty!");

            
            if (id == null)
            {
                IsMaxReached(day);
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
        public virtual void CreateActivity(string title, string content, string day)
        {
            CheckInput(title.Trim(), content.Trim(), day.Trim());
            var getDay = _dayService.GetDayByString(day.Trim());
            Activity newActivity = new Activity(){Name = title, Content = content, WeekDays = getDay};
            _activityService.AddActivity(newActivity);
            _activityService.UpdateActivity();
        }

        //Modifying an Activity
        public void EditActivity(int activityID, string title, string content, string day)
        {
            CheckInput(title, content, day, activityID);

            var currentActivity = _activityService.GetActivityById(activityID);
            var getDay = _dayService.GetDayByString(day.Trim());

            currentActivity.Name = title.Trim();
            currentActivity.Content = content.Trim();
            currentActivity.WeekDays = getDay;
            _activityService.UpdateActivity();
        }

        //Deleting an Activity
        public override void Delete(int activityID)
        {
            var currentActivity = _activityService.GetActivityById(activityID);
            _activityService.DeleteActivity(currentActivity);
            _activityService.UpdateActivity();
             currentActivity = null; //used to cause exception if you are trying to delete something again when nothing is selected
        }

    }
}
