using System;

namespace DateModify
{
    class DateModifier
    {
        public double Days { get; set; }

        public void DayDifference(DateTime timeOne, DateTime timeTwo)
        {
            Func<DateTime, DateTime, double> difference = (timeOne, timeTwo) => timeOne > timeTwo ? (timeOne - timeTwo).TotalDays : (timeTwo - timeOne).TotalDays;

            this.Days = difference(timeOne, timeTwo);
        }
    }
}
