using System;
using System.Collections;
using System.Collections.Generic;

namespace rangofechas
{
    public partial class rangosfechas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String str = Request.Form["daterange"];
            String per = Request.Form["periodo"];
            String[] fechas;

            if (str != null && per!=null)
            {
                char[] separator = { '-' };
                Int32 count = 2;
                fechas = str.Split(separator, count, StringSplitOptions.None);

                string strDate = fechas[0];
                DateTime date1 = DateTime.Today;
                if (DateTime.TryParse(strDate, out date1))
                    date1 = DateTime.Parse(strDate);
                strDate = fechas[1];
                DateTime date2 = DateTime.Today;
                if (DateTime.TryParse(strDate, out date2))
                    date2 = DateTime.Parse(strDate);
                
                object lunes= Request.Form["lunes"], 
                    martes= Request.Form["martes"], 
                    miercoles= Request.Form["miercoles"], 
                    jueves= Request.Form["jueves"], 
                    viernes= Request.Form["viernes"], 
                    sabado= Request.Form["sabado"], 
                    domingo = Request.Form["domingo"];

                bool eslunes = false,
                    esmartes = false,
                    esmiercoles = false,
                    esjueves = false,
                    esviernes = false,
                    essabado = false,
                    esdomingo = false;

                if (lunes!=null)
                {
                    eslunes = true;
                }
                if (martes!=null)
                {
                    esmartes = true;
                }
                if (miercoles!=null)
                {
                    esmiercoles = true;
                }
                if (jueves!=null)
                {
                    esjueves = true;
                }
                if (viernes!=null)
                {
                    esviernes = true;
                }
                if (sabado!=null)
                {
                    essabado = true;
                }
                if (domingo!=null)
                {
                    esdomingo = true;
                }

                BOCalendarAssignmentItem bocA = new BOCalendarAssignmentItem
                {
                    PeriodicityWeeks = Int32.Parse(Request.Form["periodo"].ToString()),
                    StartDate = date1,
                    EndDate = date2,
                    IsFriday = esviernes,
                    IsMonday = eslunes,
                    IsSaturday = essabado,
                    IsSunday = esdomingo,
                    IsThursday = esjueves,
                    IsTuesday = esmartes,
                    IsWednesday = esmiercoles
                };


                List<CalendarRange> resultado = CheckPreviousManageAssignmentItems(bocA);

                foreach (CalendarRange range in resultado)
                {
                    lblresult.Text = lblresult.Text
                                + "["
                                + Convert.ToString(range.StartRange)
                                + "," + Convert.ToString(range.EndRange.ToString()) + "]";
                }
            }
            else
            {
                lblresult.Text = "Sin Resultado." ;
            }      
        }
        public List<CalendarRange> CheckPreviousManageAssignmentItems(BOCalendarAssignmentItem FormsValues)
        {            
            List<CalendarRange> allRangeDates = new List<CalendarRange>();
            List<DateTime> rangoactual = new List<DateTime>();
            CalendarRange Temp = new CalendarRange();
            for (DateTime date = FormsValues.StartDate; date <= FormsValues.EndDate; date = date.AddDays(1))
            {
                if (FormsValues.IsMonday && date.Day.Equals("Monday"))
                {
                    rangoactual.Add(date);
                }
                if (FormsValues.IsTuesday && date.Day.Equals("Tuesday"))
                {
                    rangoactual.Add(date);
                }
                if (FormsValues.IsWednesday && date.Day.Equals("Wednesday"))
                {
                    rangoactual.Add(date);
                }
                if (FormsValues.IsThursday && date.Day.Equals("Thursday"))
                {
                    rangoactual.Add(date);
                }
                if (FormsValues.IsFriday && date.Day.Equals("Friday"))
                {
                    rangoactual.Add(date);
                }
                if (FormsValues.IsSaturday && date.Day.Equals("Saturday"))
                {
                    rangoactual.Add(date);
                }
                if (FormsValues.IsSunday && date.Day.Equals("Sunday"))
                {
                    rangoactual.Add(date);
                }
                Temp.StartRange = rangoactual[0];
                Temp.EndRange = rangoactual[rangoactual.LastIndexOf()];
                allRangeDates.Add(Temp);

                ///////////// Falta lo de la periodicidad
            }               
            return allRangeDates;
        }

        public List<DateTime> BetweenDates(string startDate, string endDate)
        {
            DateTime sdt = DateTime.ParseExact(startDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime edt = DateTime.ParseExact(endDate, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            List<DateTime> dates = new List<DateTime>();
            do
            {

                if (Days.Contains(sdt.DayOfWeek.ToString()))
                {
                    dates.Add(sdt.Date.ToString("yyyy-MM-dd"));
                }
                sdt = sdt.AddDays(1);
            } while (sdt.CompareTo(edt) != 1);
            return dates;
        }


    }
}