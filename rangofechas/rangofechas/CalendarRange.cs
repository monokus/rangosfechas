using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rangofechas
{
    public class CalendarRange
    {
        public DateTime StartRange { get; set; }

        public DateTime EndRange { get; set; }

        public Guid CalendarId { get; set; }

        public Guid CompanyId { get; set; }

        public Guid? CenterId { get; set; }

        public Guid? DepartmentId { get; set; }

        public List<Guid?> EmployeesId { get; set; }
    }
}