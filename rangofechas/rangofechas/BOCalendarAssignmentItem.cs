using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rangofechas
{
    public class BOCalendarAssignmentItem
    {
        public Guid? CalendarId { get; set; }

        public Guid? SelectedCompany { get; set; }

        public Guid? SelectedCenter { get; set; }

        public Guid? SelectedDepartment { get; set; }

        public List<Guid?> SelectedEmployees { get; set; }

        /* Fecha de inicio */

        public DateTime StartDate { get; set; }

        /* Fecha de fin */

        public DateTime EndDate { get; set; }

        /* Periodicidad en semanas (cada cuantas semanas se aplica) */

        public int PeriodicityWeeks { get; set; }

        /* Esta manera de pasar los días la puedes cambiar */

        public bool IsTuesday { get; set; }

        public bool IsWednesday { get; set; }

        public bool IsFriday { get; set; }

        public bool IsSaturday { get; set; }

        public bool IsSunday { get; set; }

        public bool IsMonday { get; set; }

        public bool IsThursday { get; set; }
    }
}