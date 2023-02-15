using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DateModifier
{
    public class DateModifier
    {
        private DateTime date1;
        private DateTime date2;

        public DateModifier(DateTime date1, DateTime date2)
        {
            Date1 = date1;
            Date2 = date2;
        }
        public DateTime Date1 { get { return date1; } set { date1 = value; } }
        public DateTime Date2 { get { return date2; } set { date2 = value; } }

        public double GetDifference()
        {
            double result = (Date1 - Date2).TotalDays;
            return result;

        }
        
    }
}
