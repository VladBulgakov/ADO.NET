using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Student
{
    class Program
    {
        static List<Student> students = new List<Student>
        {
            new Student {FirstName="Svetlana", LastName="Omelchenko", ID=1, Scores = new List<int> {97, 92, 81, 82}},
            new Student {FirstName="Claire", LastName="O’Donnell", ID=2, Scores = new List<int> {75, 84, 91, 39}},
            new Student {FirstName="Ivan", LastName="Petrov", ID=3, Scores = new List<int> {81, 70, 75, 79}},
            new Student {FirstName="Tatiana", LastName="Nevzorova", ID=4, Scores = new List<int> {92, 73, 65, 68}},
            new Student {FirstName="Anton", LastName="Belov", ID=5, Scores = new List<int> {91, 70, 85, 81}},
            new Student {FirstName="Katrin", LastName="Garcia", ID=6, Scores = new List<int> {75, 79, 86, 80}},
            new Student {FirstName="Stacie", LastName="Garcia", ID=7, Scores = new List<int> {76, 83, 85, 79}},
        };

        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery =
            from student in students
            where student.Scores[0] > 90 && student.Scores[3] < 80
            /*orderby student.LastName ascending*/
            orderby student.Scores[0] descending
            select student;
            /*foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.LastName, student.FirstName, student.Scores[0]);
            }*/

            var studentQuery2 =
            from student in students
            group student by student.LastName[0];
            /*foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("{0} {1}", student.LastName, student.FirstName);
                }
            }*/

            //Присвоение пременной неявного типа
            var studentQuery3 =
            from student in students
            group student by student.LastName[0];

            /*foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents) //Не указываем тип
                {
                    Console.WriteLine("{0} {1}", student.LastName, student.FirstName);
                }
            }*/

            var studentQuery4 =
            from student in students
            group student by student.LastName[0] into studentGroup
            orderby studentGroup.Key
            select studentGroup;

            /*foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("{0}, {1}", student.LastName, student.FirstName);
                }
            }*/

            //Ключевое слово let
            var studentQuery5 =
            from student in students
            let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
            where totalScore / 4 < student.Scores[0]
            select student.LastName + " " + student.FirstName;

            /*foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }*/

            //Использование синтаксиса метода в выражении запроса
            var studentQuery6 =
            from student in students
            let totalScore = student.Scores[0] + student.Scores[1] +
            student.Scores[2] + student.Scores[3]
            select totalScore;

            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);

            //Преобразование и проецирование
            IEnumerable<string> studentQuery7 =
                from student in students
                where student.LastName == "Garcia"
                select student.FirstName;
            /*Console.WriteLine("The Garcias in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }*/

            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }


        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }
}
