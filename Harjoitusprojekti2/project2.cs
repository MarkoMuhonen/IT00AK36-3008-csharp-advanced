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


            PrintAllStudents(students);

            // TODO: Test methods here
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
            foreach (Student student in students)
            {
                if (student.Name == name)
                {
                    Console.WriteLine(student);
                    return;
                }
            }
            Console.WriteLine("Student not found.");
        }

        static void PrintStudentsOlderThan(List<Student> students, int age)
        {
            // TODO
        }

        static void PrintStudentsByProgram(List<Student> students, string program)
        {
            // TODO
        }

        static void PrintAllStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }
        }
    }

