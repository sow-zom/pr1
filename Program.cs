using System;

namespace pr1
{
    struct Airplane
    {
        public string StartCity, FinishCity;
        public Date StartDate, FinishDate;

        public Airplane(string a, string b, Date c, Date d)
        {
            StartCity = a;
            FinishCity = b;
            StartDate = c;
            FinishDate = d;
        }
        public int GetTotalTime()
        {
            int time = ((FinishDate.Year - StartDate.Year) * (365 * 1440));
            if (FinishDate.Month < StartDate.Month)
            {
                time += FinishDate.Month * 1440;
            }
            else
            {
                time += (FinishDate.Month - StartDate.Month) * 1440;
            }
            if (FinishDate.Day < StartDate.Day)
            {
                time += FinishDate.Day * 1440;
            }
            else
            { 
            time += (FinishDate.Day - StartDate.Day) * 1440;
            }

            if (FinishDate.Hours < StartDate.Hours)
            {
                time += FinishDate.Hours * 60;
            }
            else
            {
                time += (FinishDate.Hours - StartDate.Hours) * 60;
            }
            if (FinishDate.Minutes < StartDate.Minutes)
            {
                time += FinishDate.Minutes;
            }
            else
            {
                time += (FinishDate.Minutes - StartDate.Minutes);
            }

            return time;
        }
        public bool IsArrivingToday()
        {
            return StartDate.Day == FinishDate.Day;
        }
    }
    struct Date
    {
        public int Year, Month, Day, Hours, Minutes;
        
        public Date(int year = 0, int month = 0, int day = 0, int hours = 0, int minutes = 0)
        {
            Year = year;
            Month = month;
            Day = day;
            Hours = hours;
            Minutes = minutes;
        }
    }

    class Program
    {
        static Airplane[] ReadAirplaneArray()
        {

            int size_array;
            Console.WriteLine("count flight>>");
            size_array = Convert.ToInt32(Console.ReadLine());
            Airplane[] temp_arr = new Airplane[size_array];

            for (int i = 0; i < size_array; i++)
            {
                Console.WriteLine("flight №>>" + (i + 1));
                Console.WriteLine("StartCity mane>> ");
                temp_arr[i] = new Airplane();
                temp_arr[i].StartCity = Console.ReadLine();
                Console.WriteLine("FinishCity name>> ");
                temp_arr[i].FinishCity = Console.ReadLine();
                Console.WriteLine();
                Date temp_date_input = new Date();
                Console.WriteLine("year>>");
                temp_date_input.Year = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("month>>");
                temp_date_input.Month = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("day>>");
                temp_date_input.Day = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("hour>>");
                temp_date_input.Hours = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("min>>");
                temp_date_input.Minutes = (Convert.ToInt32(Console.ReadLine()));
                temp_arr[i].StartDate = (temp_date_input);
                Console.WriteLine();
                Date temp_date_out = new Date();
                Console.WriteLine("year>>");
                temp_date_out.Year = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("month>>");
                temp_date_out.Month = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("day>>");
                temp_date_out.Day = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("hour>>");
                temp_date_out.Hours = (Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("min>>");
                temp_date_out.Minutes = (Convert.ToInt32(Console.ReadLine()));
                temp_arr[i].FinishDate = (temp_date_out);
            }
            return temp_arr;
        }

        static void PrintAirplanes(Airplane[] o)
        {
            Console.WriteLine();
            for (int i = 0; i < o.Length; i++)
            {
                Console.WriteLine("\nflight №" + (i + 1));
                PrintAirplane(o[i]);
            }

        }
        static void PrintAirplane(Airplane o)
        {
            Console.WriteLine("start sity - " + o.StartCity);
            Console.WriteLine("finish sity  - " + o.FinishCity);
            Console.WriteLine("date start    - " + o.StartDate.Year + "," + o.StartDate.Month + "," + o.StartDate.Day + "," + o.StartDate.Hours + ":" + o.StartDate.Minutes + ".");
            Console.WriteLine("date finish   - " + o.FinishDate.Year + "," + o.FinishDate.Month + "," + o.FinishDate.Day + "," + o.FinishDate.Hours + ":" + o.FinishDate.Minutes + ".");
        }
        static void GetAirplaneInfo(Airplane[] o, out int max_time, out int min_time)
        {
            max_time = o[0].GetTotalTime();
            min_time = max_time;
            for (int i = 1; i < o.Length; i++)
            {
                if (max_time < o[i].GetTotalTime())
                {
                    max_time = o[i].GetTotalTime();
                }
                else if (min_time > o[i].GetTotalTime())
                {
                    min_time = o[i].GetTotalTime();
                }
            }
        }

        static Airplane[] SortAirplanesByDate(Airplane[] o)
        {
            for (int i = 1; i < o.Length; i++)
            {
                for (int j = 0; j < o.Length - i; j++)
                {
                    if (o[j].StartDate.Year > o[j].StartDate.Year ||
                        (o[j].StartDate.Year == o[j].StartDate.Year && o[j].StartDate.Month > o[j + 1].StartDate.Month) ||
                        (o[j].StartDate.Year == o[j].StartDate.Year && o[j].StartDate.Month == o[j + 1].StartDate.Month && o[j].StartDate.Day > o[j + 1].StartDate.Day) ||
                        (o[j].StartDate.Year == o[j].StartDate.Year && o[j].StartDate.Month == o[j + 1].StartDate.Month && o[j].StartDate.Day == o[j + 1].StartDate.Day && o[j].StartDate.Hours > o[j + 1].StartDate.Hours) ||
                        (o[j].StartDate.Year == o[j].StartDate.Year && o[j].StartDate.Month == o[j + 1].StartDate.Month && o[j].StartDate.Day == o[j + 1].StartDate.Day && o[j].StartDate.Hours == o[j + 1].StartDate.Hours && o[j].StartDate.Minutes > o[j + 1].StartDate.Minutes))
                    {
                        Airplane to;
                        to = o[j];
                        o[j] = o[j + 1];
                        o[j + 1] = to;
                    }
                }
            }
            return o;
        }

        static Airplane[] SortAirplanesByTotalTime(Airplane[] o)
        {
            for (int i = 1; i < o.Length; i++)
            {
                for (int j = 0; j < o.Length - i; j++)
                {
                    if (o[j].GetTotalTime() > o[j + 1].GetTotalTime())
                    {
                        Airplane to;
                        to = o[j];
                        o[j] = o[j + 1];
                        o[j + 1] = to;
                    }
                }
            }
            return o;
        }
        static void Main()
        {
            Airplane[] structArray = ReadAirplaneArray();
            PrintAirplanes(structArray);
            int max_time, min_time;
            GetAirplaneInfo(structArray, out max_time, out min_time);
            Console.WriteLine("\nMax time - " + max_time + "\n Min time - " + min_time);
            Console.WriteLine("\nSortAirplanesByDate: \n ");
            PrintAirplanes(SortAirplanesByDate(structArray));
            Console.WriteLine("\nSortAirplanesByTotalTime: \n");
            PrintAirplanes(SortAirplanesByTotalTime(structArray));
            Console.ReadKey();
        }
    }
}
