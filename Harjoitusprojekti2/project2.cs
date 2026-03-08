using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

class Student
{
    // opiskelija luokka, jota käytetään tietojen varastoinnissa listalla
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
        List<Student> students = new List<Student>(); // luodaan "tietovarasto" opiskelijoille listana

        // testataan opskielijoiden lisäystä ja tulostusta
        AddStudent(students, new Student("Jorma Kemppainen", 22, "Putkitekniikka"));
        AddStudent(students, new Student("Keijo Vilunki", 22, "Taloustiede"));
        AddStudent(students, new Student("Raija Rätinki", 19, "Taloushallinto"));
        AddStudent(students, new Student("Anna", 20, "ICT"));
        AddStudent(students, new Student("Mikko", 23, "Business"));
        AddStudent(students, new Student("Liisa", 21, "ICT"));
        AddStudent(students, new Student("Pekka", 25, "Engineering"));

        Console.WriteLine("\nAll students:");
        PrintAllStudents(students);             // listataan kaikki, testataan että lisäys on toiminut


        // lisää testikoodia, jolla testataan opiskelijoiden hakua ja listausta eri hauilla

        Console.WriteLine("\n");
        PrintStudentsOlderThan(students, 21); // testataan ikä > 21
        Console.WriteLine("\nSearching by student age:");   // testataan opiskelijoiden hakua iän perusteella
        FindStudentByAge(students, 22);                             // opiskelijoita on iältään 22
        FindStudentByAge(students, 30);                             // opiskelijoita ei ole

        Console.WriteLine("\nTesting by student name:");    // testataan opiskelijoiden hakua nimellä
        FindStudentByName(students, "Raija Rätinki");       // opiskelija on listalla
        FindStudentByName(students, "Tarmo Tampiola");      // opiskelija ei ole listalla

        Console.WriteLine("\nListing Students by Program:");
        PrintStudentsByProgram(students, "ICT");            // opiskelijoita on ICT-ohjelmassa
        PrintStudentsByProgram(students, "Rocketscience");   // opiskelijoita ei ole



    }

    static void AddStudent(List<Student> students, Student student)
    {
        // lisätään opiskelija listaan   TODO: duplikaatin tarkistus
        students.Add(student);
        Console.WriteLine("Student added: " + student);
    }

    static void FindStudentByName(List<Student> students, string name)
    {
        // etsitään nimen perusteella opsikelijaa, tulostetaan tai ilmoitetaan virheestä 
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
        // tulostetaan kaikki haettua ikää vanhemmat opiskelijat tietoineen tai ilmoitetaan virheestä
        bool found = false;
        Console.WriteLine("Students older than " + age + ":");
        foreach (Student student in students)
        {
            if (student.Age > age)
            {
                Console.WriteLine(student);
                found = true;
            }
        }
        if (!found)            // jos ei löydy yhtään vanhempaa opiskelijaa, ilmoitetaan siitä kts. found-muuttuja
        {
            Console.WriteLine("No students found older than " + age);
            return;
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
        // etsitään ja listataan tietyn opiontosuunnan opiskelijat tai ilmoitetaan virheestä
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
        // tulostetaan kaikki opiskelijat tietoineen
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }
}

