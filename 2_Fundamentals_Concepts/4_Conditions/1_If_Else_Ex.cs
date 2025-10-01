using System;

namespace _4_Conditions;

public class _1_If_Else_Ex
{
    public static void AnalyzeTemperature(double temperature)
    {
        Console.WriteLine($"Current temperature: {temperature}°C");

        if (temperature > 35.0)
        {
            Console.WriteLine("🔥 HEAT WARNING: Extreme heat conditions.");
            Console.WriteLine("💡 Advice: Stay indoors, drink plenty of water.");

        }
        else if (temperature > 25.0)
        {
            Console.WriteLine("☀️ Warm weather: Pleasant conditions.");
            Console.WriteLine("💡 Advice: Perfect for outdoor activities.");
        }
        else if (temperature > 15.0)
        {
            Console.WriteLine("🌤️ Mild weather: Comfortable conditions.");
            Console.WriteLine("💡 Advice: Light jacket recommended.");
        }
        else if (temperature > 5.0)
        {
            Console.WriteLine("❄️ Cool weather: Chilly conditions.");
            Console.WriteLine("💡 Advice: Wear warm clothing.");
        }
        else if (temperature > -10.0)
        {
            Console.WriteLine("🥶 Cold weather: Freezing conditions.");
            Console.WriteLine("💡 Advice: Heavy winter gear required.");
        }
        else
        {
            Console.WriteLine("🚨 EXTREME COLD WARNING: Dangerously cold!");
            Console.WriteLine("💡 Advice: Limit outdoor exposure.");

        }
    }

    /// Grade Classification System
    public static string CalculateGrade(int score)
    {
        string grade;

        if (score >= 90 && score <= 100)
        {
            grade = "A";
            Console.WriteLine("Excellent! Outstanding performance.");
        }
        else if (score >= 80 && score < 90)
        {
            grade = "B";
            Console.WriteLine("Very good! Strong performance.");
        }
        else if (score >= 70 && score < 80)
        {
            grade = "C";
            Console.WriteLine("Good! Satisfactory performance.");
        }
        else if (score >= 60 && score < 70)
        {
            grade = "D";
            Console.WriteLine("Needs improvement. Passing but weak.");
        }
        else if (score >= 0 && score < 60)
        {
            grade = "F";
            Console.WriteLine("Failed. Significant improvement needed.");
        }
        else
        {
            grade = "Invalid";
            Console.WriteLine("ERROR: Score must be between 0-100.");
        }

        return grade;
    }

}
