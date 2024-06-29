using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string continueChoice;
        do
        {
            Console.WriteLine("Введите год:");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите месяц:");
            int month = Convert.ToInt32(Console.ReadLine());

            PrintCalendar(month, year);

            Console.WriteLine("Хотите посмотреть другой год или месяц? (да/нет)");
            continueChoice = Console.ReadLine();

        } while (continueChoice.ToLower() == "да");
    }

    static void PrintCalendar(int month, int year)
    {
        Console.WriteLine("\n     Календарь для {0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), year);
        Console.WriteLine(" Пн  Вт  Ср  Чт  Пт  Сб  Вс");
        Console.WriteLine("-----------------------------");

        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        int offset = ((int)firstDayOfMonth.DayOfWeek + 6) % 7; 

        for (int i = 0; i < offset; i++)
        {
            Console.Write("    ");
        }

        int daysInMonth = DateTime.DaysInMonth(year, month);

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write("{0,3} ", day);

            if ((day + offset) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine("\n-----------------------------");
    }
}
