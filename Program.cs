// See https://aka.ms/new-console-template for more information
using DotNetAdvancedHerhalingsopdracht.Model;
using DotNetAdvancedHerhalingsopdracht.Repositories;
using Microsoft.Data.SqlClient;
using System.Configuration;

//Database
string? connectionString = ConfigurationManager.AppSettings["connectionString"]; //From App.config file
//string? connectionString = ConfigurationManager.AppSettings["connectionStringBad"]; //Connection Test
var connectionStudents = new SqlConnection(connectionString);
var connectionTeachers = new SqlConnection(connectionString);
using var studentRepository = new StudentRepository(connectionStudents);
using var teacherRepository = new TeacherRepository(connectionTeachers);

//Some Students/Teachers
var student1 = new Student
{
    FirstName = "Gert",
    LastName = "Van Hamme",
    Age = 30,
    Year = 2023
};

var teacher1 = new Teacher
{
    FirstName = "Wannes",
    LastName = "Gennar",
    Age = 28,
    Course= new string[1] {".Net Advanced"}
};

//Insert people into database
try
{
    studentRepository.AddStudent(student1);
}catch(Exception ex) {  Console.WriteLine(ex.Message); }
try
{
    teacherRepository.AddTeacher(teacher1);
}
catch (Exception ex) { Console.WriteLine(ex.Message); }

try
{
    var studentGet = studentRepository.GetById(100);
    Console.WriteLine(studentGet);
}
catch (Exception ex) { Console.WriteLine(ex.Message); }
try
{
    var teacherGet = teacherRepository.GetById(1);
    Console.WriteLine(teacherGet);
}
catch (Exception ex) { Console.WriteLine(ex.Message); }



;

//OOP
//DeclareName(student1);

//List<Person> persons = new List<Person>();
//persons.Add(student1);
//persons.Add(teacher1);

//foreach (Person person in persons)
//{
//    Print(person);
//    Console.WriteLine("Age: {0}", person.Age);
//}
static void Print(Person person)
{
    Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
}
static void DeclareName(Person person)
{
    Console.WriteLine("Enter first name:");
    var firstName = Console.ReadLine();
    Console.WriteLine("Enter last name:");
    var lastName = Console.ReadLine();
    Console.WriteLine("You entered: {0} {1}", firstName, lastName);

    person.FirstName = firstName;
    person.LastName = lastName;

}
