using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

class Student
    {
        public string Name;
        public int Age;
        public string DegreeProgram;

        public Student(string name, int age, string degreeProgram)
        {
            Name = name;
            Age = age;
            DegreeProgram = degreeProgram;
        }

        public override string ToString()
        {
            return Name + ", " + Age + " years, Program: " + DegreeProgram;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            // TODO: Add initial students here
            AddStudent(students, new Student("Jorma Kemppainen", 22, "Putkitekniikka"));
            AddStudent(students, new Student("Keijo Vilunki", 22, "Taloustiede"));
            AddStudent(students, new Student("Raija Rätinki", 19, "Taloushallinto"));
            AddStudent(students, new Student("Anna", 20, "ICT"));
            AddStudent(students, new Student("Mikko", 23, "Business"));
            AddStudent(students, new Student("Liisa", 21, "ICT"));
            AddStudent(students, new Student("Pekka", 25, "Engineering"));

            Console.WriteLine("\nAll students:");
            PrintAllStudents(students);

            // TODO: Test methods here

            Console.WriteLine("\n");
            PrintStudentsOlderThan(students, 21); // testataan ikä > 21

            Console.WriteLine("\nTesting by student name:");    // testataan opiskelijoiden hakua nimellä
            FindStudentByName(students, "Raija Rätinki");       // opiskelija on listalla
            FindStudentByName(students, "Tarmo Tampiola");      // opiskelija ei ole listalla
            Console.WriteLine("\nSearching by student age:");   // testataan opiskelijoiden hakua iän perusteella
            FindStudentByAge(students, 22);                             // opiskelijoita on iältään 22
            FindStudentByAge(students, 30);                             // opiskelijoita ei ole
        }

        static void AddStudent(List<Student> students, Student student)
        {
            // TODO
            students.Add(student);
            Console.WriteLine("Student added: " + student);
        }

        static void FindStudentByName(List<Student> students, string name)
        {
            // TODO
            Console.WriteLine("Searching for student: " + name);
            foreach (Student student in students)
            {
                if (student.Name == name)
                {
                    Console.WriteLine("Student found: " + student);
                    return;
                }
            }
            Console.WriteLine("Student " + name + " not found.");
        }

        static void PrintStudentsOlderThan(List<Student> students, int age)
        {
            // TODO
            Console.WriteLine("Students older than " + age + ":");
            foreach (Student student in students)
            {
                if (student.Age > age)
                {
                    Console.WriteLine(student);
                }
            }
        }


        static void FindStudentByAge(List<Student> students, int age)
        {
            // lisätoiminnallisuus: listataan tietyn ikäiset opiskelijat, tai ilmoitetaan, jos ei löydy
            Console.WriteLine("Students with age " + age + ":");
            foreach (Student student in students)
            {
                if (student.Age == age)
                {
                    Console.WriteLine(student);
                }
                else
                {
                    Console.WriteLine("No students found with age " + age);
                    return;
                }
            }
        }

        static void PrintStudentsByProgram(List<Student> students, string program)
        {
            // TODO
            Console.WriteLine("Students in program " + program + ":");
            foreach (Student student in students)
            {
                if (student.DegreeProgram == program)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void PrintAllStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

