using System;

namespace _4_Conditions;

public class _2_Switch_Case_Ex
{


    public static void ProcessDayOfWeek(int dayNumber)
    {
        string dayName;
        string message;

        switch (dayNumber)
        {
            case 1:
                dayName = "Monday";
                message = "Start of the work week. Time to be productive!";
                break;
            case 2:
                dayName = "Tuesday";
                message = "Getting into the flow of the week.";
                break;
            case 3:
                dayName = "Wednesday";
                message = "Hump day! Halfway through the week.";
                break;
            case 4:
                dayName = "Thursday";
                message = "Almost there! One more day until Friday.";
                break;
            case 5:
                dayName = "Friday";
                message = "Last work day! Weekend is almost here.";
                break;
            case 6:
                dayName = "Saturday";
                message = "Weekend! Time to relax and have fun.";
                break;
            case 7:
                dayName = "Sunday";
                message = "Rest day. Prepare for the week ahead.";
                break;
            default:
                dayName = "Unknown";
                message = "Invalid day number. Please enter 1-7.";
                break;
        }

        Console.WriteLine($"Day {dayNumber}: {dayName}");
        Console.WriteLine(message);
    }
}
