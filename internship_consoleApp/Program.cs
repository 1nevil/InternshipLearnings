using internship_consoleApp.models;

List<Students> students = new List<Students>();
students.Add(new Students { Id = 1, Name = "nevil", City = "surat" });
students.Add(new Students { Id = 2, Name = "javal", City = "vadodra" });
students.Add(new Students { Id = 3, Name = "raj", City = "delhi" });
students.Add(new Students { Id = 4, Name = "jay", City = "hydrabad" });
students.Add(new Students { Id = 5, Name = "jamin", City = "surat" });

foreach (var student in students)
{
    Console.WriteLine("StudentId : {0} Name : {1} City : {2}", student.Id, student.Name, student.City);
}

//It is check reference so that is return false
Students studentRaj = new Students { Id = 3, Name = "raj", City = "delhi" };
if (students.Contains(studentRaj))
{
    Console.WriteLine("Found");
}
else
{
    Console.WriteLine("not Found");

}

//sort by name
//var sortedStudents = students.OrderBy(s => s.Name);

//OrderBy return IEnumerable - efficient 
//IEnumerable<Students> sortedStudent = students.OrderBy(s => s.Name);

//OrderBy return IEnumerable we need to convert into the list
//List<Students> sortedStudents = students.OrderBy(s => s.Name).ToList();

//bool isStudentExists = students.Exists(x => x.Name == "raj");
bool isStudentExists = students.Exists(x => x.Name.StartsWith("r")); //return boolean

if (isStudentExists)
{
    Console.WriteLine("Found");
}


//Find
Students? stud = students.Find(s => s.Name == "raj");
Console.WriteLine("StudentId : {0} Name : {1} City : {2}", stud?.Id, stud?.Name, stud?.City);

//Find All
List<Students>? studentsSurat = students.FindAll(s => s.City == "surat");
foreach (var student in studentsSurat)
{
    Console.WriteLine("StudentId : {0} Name : {1} City : {2}", student.Id, student.Name, student.City);
}
