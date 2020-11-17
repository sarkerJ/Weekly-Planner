using System;
using System.Collections.Generic;
using System.Text;

namespace Weekly_PlannerDataLayer.Services
{
    interface IActivityService
    {
        Activity GetActivityById(int id);
        Activity GetActivityByName(string name);
        Activity GetActivityByNameAndId(string name, int? id);
        void UpdateActivity();
        void DeleteActivity(Activity activity);
        void AddActivity(Activity activity);
        List<Activity> GetListOfActivitiesByDay(string day);

        int GetActivitiesCountByDay(string day);
    }
}
