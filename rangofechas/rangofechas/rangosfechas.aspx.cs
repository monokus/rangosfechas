using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace rangofechas
{
    public partial class rangosfechas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String str = Request.Form["daterange"];
            String per = Request.Form["periodo"];
            String[] fechas;
            String[] parts;

            if (str != null && per!=null)
            {
                char[] separator = { '-' };
                Int32 count = 2;
                fechas = str.Split(separator, count, StringSplitOptions.None);

                char[] separ = { '/' };
                Int32 c = 3;

                parts = fechas[0].Trim().Split(separ, c, StringSplitOptions.None);
                DateTime date1 = new DateTime(Int32.Parse(parts[2]), Int32.Parse(parts[0]), Int32.Parse(parts[1]));

                parts = fechas[1].Trim().Split(separ, c, StringSplitOptions.None);                
                DateTime date2 = new DateTime(Int32.Parse(parts[2]), Int32.Parse(parts[0]), Int32.Parse(parts[1]));

                                   
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

                // Determina el result
                List<CalendarRange> resultado = CheckPreviousManageAssignmentItems(bocA);

                foreach (CalendarRange range in resultado)
                {
                    lblresult.Text = lblresult.Text
                                + "["
                                + Convert.ToString(range.StartRange)
                                + "," + Convert.ToString(range.EndRange.ToString()) + "] ";
                }
            }
            else
            {
                lblresult.Text = "Sin Resultado." ;
            }      
        }
        List<CalendarRange> CheckPreviousManageAssignmentItems(BOCalendarAssignmentItem FormsValues)
        {
            List<CalendarRange> allRangeDates = new List<CalendarRange>();

            List<DateTime> rangoactual = new List<DateTime>();

            CalendarRange Temp = new CalendarRange();

            var inicio = FormsValues.StartDate;

            var fin = FormsValues.EndDate;

            int cantidadDias = fin.Subtract(inicio).Days + 1;           

            List<DayOfWeek> workDays = new List<DayOfWeek>();

            int cantidadmarcados = 0;

            if (FormsValues.IsMonday)
            {
               workDays.Add(DayOfWeek.Monday);
               cantidadmarcados++;
            }
            if (FormsValues.IsTuesday)
            {
                workDays.Add(DayOfWeek.Tuesday);
                cantidadmarcados++;
            }
            if (FormsValues.IsWednesday)
            {
                workDays.Add(DayOfWeek.Wednesday);
                cantidadmarcados++;
            }
            if (FormsValues.IsThursday)
            {
                workDays.Add(DayOfWeek.Thursday);
                cantidadmarcados++;
            }
            if (FormsValues.IsFriday)
            {
                workDays.Add(DayOfWeek.Friday);
                cantidadmarcados++;
            }
            if (FormsValues.IsSaturday)
            {
                workDays.Add(DayOfWeek.Saturday);
                cantidadmarcados++;
            }
            if (FormsValues.IsSunday)
            {
                workDays.Add(DayOfWeek.Sunday);
                cantidadmarcados++;
            }
            var fechas = Enumerable.Range(0, cantidadDias)
                                  .Select(i => inicio.AddDays(i))
                                  .Where(d => workDays.Contains(d.DayOfWeek));

            var r = fechas.ToList();


            for (int i = 0; i<= r.Count-1; i++)
            {
                for (int j = 0;j<=cantidadmarcados && i<=r.Count-1;j++)
                {
                    if ((r[i].DayOfWeek == DayOfWeek.Sunday) && FormsValues.IsSunday)
                    {
                        rangoactual.Add(r[i]);
                        i++;
                    }
                    if ((r[i].DayOfWeek == DayOfWeek.Monday) && FormsValues.IsMonday)
                    {
                        rangoactual.Add(r[i]);
                        i++;
                    }
                    if ((r[i].DayOfWeek == DayOfWeek.Tuesday) && FormsValues.IsTuesday)
                    {
                        rangoactual.Add(r[i]);
                        i++;
                    }
                    if ((r[i].DayOfWeek == DayOfWeek.Wednesday) && FormsValues.IsWednesday)
                    {
                        rangoactual.Add(r[i]);
                        i++;
                    }
                    if ((r[i].DayOfWeek == DayOfWeek.Thursday) && FormsValues.IsThursday)
                    {
                        rangoactual.Add(r[i]);
                        i++;
                    }
                    if ((r[i].DayOfWeek == DayOfWeek.Friday) && FormsValues.IsFriday)
                    {
                        rangoactual.Add(r[i]);
                        i++;
                    }
                    if ((r[i].DayOfWeek == DayOfWeek.Saturday) && FormsValues.IsSaturday)
                    {
                        rangoactual.Add(r[i]);
                        i++;
                    }
                }
                Temp.StartRange = rangoactual[0];
                Temp.EndRange = rangoactual[rangoactual.Count-1];
                allRangeDates.Add(Temp);                    
            }

            return allRangeDates;
        }
    }
}