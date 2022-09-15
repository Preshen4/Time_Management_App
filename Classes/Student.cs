using System;

namespace Time_Management_App.Classes
{
    public class Student
    {
        public int NumOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        // Instants of the Student Class as NumOfWeeks is used in calculations in the capture form
        public static Student Instant { get; } = new Student();
    }
}
