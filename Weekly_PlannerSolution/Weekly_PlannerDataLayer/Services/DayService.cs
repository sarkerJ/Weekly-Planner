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

        public DayService (WeeklyPlannerDBContext context) => _context = context;

        //Get Day
        public WeekDay GetDayByActivity(Activity activity)
        {
            var getDay = _context.Activities.Where(a => a.ActivityId == activity.ActivityId).Include(o => o.WeekDays).FirstOrDefault();
            return getDay.WeekDays;
        }

        //Get Day List
        public List<WeekDay> GetListOfDays() => _context.WeekDays.ToList();
        public List<String> GetListOfDaysString()
        {
            List<String> days = new List<string>();
            foreach (var item in _context.WeekDays.ToList()) days.Add(item.Day);
            return days;
        }

        //Get Day by Type
        public WeekDay GetDayByNote(Note note) => _context.Notes.Where(a => a.NoteId == note.NoteId).Include(o => o.WeekDays).Select(s => s.WeekDays).FirstOrDefault();
        
        public WeekDay GetDayByString(string day) => _context.WeekDays.Where(w => w.Day == day.Trim()).FirstOrDefault();

       
    }
}
