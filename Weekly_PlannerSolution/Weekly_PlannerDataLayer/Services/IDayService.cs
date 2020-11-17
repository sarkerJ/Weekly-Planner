using System;
using System.Collections.Generic;
using System.Text;

namespace Weekly_PlannerDataLayer.Services
{
    interface IDayService
    {
        WeekDay GetDayByString(string day);

        List<WeekDay> GetListOfDays();

        List<String> GetListOfDaysString();

        WeekDay GetDayByActivity(Activity activity);

    }
}
