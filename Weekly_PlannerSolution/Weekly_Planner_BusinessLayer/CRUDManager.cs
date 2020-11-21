using System;
using System.Collections.Generic;
using System.Text;
using Weekly_PlannerDataLayer;
using Weekly_PlannerDataLayer.Services;


namespace Weekly_Planner_BusinessLayer
{
    public abstract class CRUDManager
    {

        public abstract void CheckInput(string title, string content, string day=null, int? id = null);

        public abstract List<WeekDay> ListOfDays();

        public abstract List<string> ListOfDaysString();
    }
}
