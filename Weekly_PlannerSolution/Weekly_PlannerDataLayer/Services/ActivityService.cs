using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;



namespace Weekly_PlannerDataLayer.Services
{
    public class ActivityService : IActivityService
    {
        private readonly WeeklyPlannerDBContext _context;
        public ActivityService (WeeklyPlannerDBContext context) => _context = context;
        
        //add/delete/update
        public void AddActivity(Activity activity) => _context.Activities.Add(activity);
        public void DeleteActivity(Activity activity) => _context.Activities.RemoveRange(activity);
        public void UpdateActivity() => _context.SaveChanges();

        //count
        public int GetActivitiesCountByDay(string day) => _context.Activities.Include(o => o.WeekDays).Where(w => w.WeekDays.Day == day.Trim()).ToList().Count();
        
        //Get Activity
        public Activity GetActivityById(int id) => _context.Activities.Where(a => a.ActivityId == id).FirstOrDefault();
        public Activity GetActivityByName(string name) => _context.Activities.Where(a => a.Name == name.Trim()).FirstOrDefault();
        public Activity GetActivityByNameAndId(string name, int? id) =>  _context.Activities.Where(a => a.Name == name.Trim() & a.ActivityId != id).FirstOrDefault();

        //Get Activity List
        public List<Activity> GetListOfActivitiesByDay(string day) => _context.Activities.Include(o => o.WeekDays).Where(w => w.WeekDays.Day == day.Trim()).ToList();
        

        
    }
}
