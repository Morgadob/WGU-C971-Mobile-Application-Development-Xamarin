using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Contacts.Classes
{
    public static class Global
    {
        public static Terms CurrTerm { get; set; }

        public static Courses CurrCourse { get; set; }

        public static Assessment CurrAsses { get; set; }

        



        public static void AddTermData()
        {
            Terms term1 = new Terms()
            {
                TermID = 1,
                TermName = "Summer 2021",
                Start = Convert.ToDateTime("07/01/2021"),
                End = Convert.ToDateTime("01/01/2022")


            };


            using (SQLiteConnection con = new SQLiteConnection(App.FilePath))
            {
                con.CreateTable<Terms>();
                con.Insert(term1);
            };
        }

        public static void AddCourseData()
        {
            Courses course1 = new Courses()
            {
                CourseID = 1,
                TermID = 1,
                CourseName = "Software 2",
                Status = "Completed",
                StartDate = Convert.ToDateTime("07/01/2021"),
                EndDate = Convert.ToDateTime("09/01/2022"),
                InstructorName = "Brandon Morgado",
                InstructorPhone = "111-222-3345",
                InstructorEmail = "brandon.morgado@wgu.edu",
                Notes = "Completed accurately, and on time.",
                NotificationEnabled = false

            };


            using (SQLiteConnection con2 = new SQLiteConnection(App.FilePath))
            {
                con2.CreateTable<Courses>();
                con2.Insert(course1);
            };
        }

        public static void AddAssessmentData()
        {
            Assessment assess1 = new Assessment()
            {
                AssessmentID = 1,
                CourseID = 1,
                Name = "Scheduling Application",
                Type = "Objective Assessment",
                Start = Convert.ToDateTime("07/01/2021"),
                End = Convert.ToDateTime("09/01/2021"),
                NotificationEnabled = false
            };

            Assessment assess2 = new Assessment()
            {
                AssessmentID = 2,
                CourseID = 1,
                Name = "Scheduling Application Exam",
                Type = "Performance Assessment",
                Start = Convert.ToDateTime("08/15/2021"),
                End = Convert.ToDateTime("08/15/2021"),
                NotificationEnabled = false
            };



            using (SQLiteConnection con3 = new SQLiteConnection(App.FilePath))
            {
                con3.CreateTable<Assessment>();
                con3.Insert(assess1);
                con3.Insert(assess2);
            };
        }



    }
}
