using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Weekly_PlannerDataLayer.Services
{
    public class DayService : IDayService
    {
        private readonly WeeklyPlannerDBContext _context;

        public DayService (WeeklyPlannerDBContext service)
        {
            _context = service;
        }

        public WeekDay GetDayByActivity(Activity activity)
        {
            var getDay = _context.Activities.Where(a => a.ActivityId == activity.ActivityId).Include(o => o.WeekDays).FirstOrDefault();

            return getDay.WeekDays;

        }

        public WeekDay GetDayByString(string day)
        {
           return _context.WeekDays.Where(w => w.Day == day.Trim()).FirstOrDefault();
        }

        public List<WeekDay> GetListOfDays()
        {
            return _context.WeekDays.ToList();
        }

        public List<String> GetListOfDaysString()
        {
            List<String> days = new List<string>();
            foreach (var item in _context.WeekDays.ToList()) days.Add(item.Day);
            return days;
        }
    }
}
