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
        public ActivityService (WeeklyPlannerDBContext context)
        {
            _context = context;
        }

        public void AddActivity(Activity activity)
        {
            _context.Activities.Add(activity);
        }

        public void DeleteActivity(Activity activity)
        {
            _context.Activities.RemoveRange(activity);
        }

        public int GetActivitiesCountByDay(string day)
        {
            return _context.Activities.Include(o => o.WeekDays).Where(w => w.WeekDays.Day == day.Trim()).ToList().Count();
        }

        public Activity GetActivityById(int id)
        {
           return _context.Activities.Where(a => a.ActivityId == id).FirstOrDefault();
        }

        public Activity GetActivityByName(string name)
        {
            return _context.Activities.Where(a => a.Name == name.Trim()).FirstOrDefault();
        }

        public Activity GetActivityByNameAndId(string name, int? id)
        {
            return _context.Activities.Where(a => a.Name == name.Trim() & a.ActivityId != id).FirstOrDefault();
        }

        public List<Activity> GetListOfActivitiesByDay(string day)
        {
           return _context.Activities.Include(o => o.WeekDays).Where(w => w.WeekDays.Day == day.Trim()).ToList();
        }

        public void UpdateActivity()
        {
            _context.SaveChanges();
        }
    }
}
