// Code By Wpooley

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsolePlayGround
{
    public static class DatePlay
    {
        public static double DaysBetweenTwoDates(DateTime d1, DateTime d2)
        {
            return (d1 - d2).TotalDays;
        }
        public static DateTime AddWeeksToDate(DateTime d1, int weeks)
        {
            int days = weeks * 7;
            return d1.AddDays(days);
        }
    }
}
