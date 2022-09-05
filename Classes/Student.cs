using System;

namespace Time_Management_App.Classes
{
    public class Student
    {
        public int NumOfWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public static Student Instant { get; } = new Student();
    }
}
