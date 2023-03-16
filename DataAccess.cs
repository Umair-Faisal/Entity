using System.ComponentModel;
using DataProjectLib;

namespace ConsoleAppUI
{
    public static class DataAccess
    {

        public static void      AddStudent()
        {

            Console.WriteLine("Enter Information of Student:");
            Console.Write("Roll No. : ");
            int RollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name : ");
            string FirstName = Console.ReadLine();
            Console.Write("Last Name : ");
            string LastName = Console.ReadLine();
            Console.Write("CGPA : ");
            decimal CGPA = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Session : ");
            int Session = Convert.ToInt32(Console.ReadLine());

            Student student = new Student(RollNo, FirstName, LastName, CGPA);

            using (var context = new Context())
            {
                context.Students.Add(student);
                var session = context.Sessions.Single(b => b.Year == Session);
                session.Students.Add(student);
                context.SaveChanges();
            }
        }

        public static void      GetStudent(int roll)
        {
            try
            {
                Student uStudent = ReturnStudent(roll);
                PrintInfo<Student>(uStudent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No Student Found");
            }

        }
        public static void      UpdateStudent(int roll)
        {
            try
            {
                Student uStudent = ReturnStudent(roll);
                PrintInfo<Student>(uStudent);
                Console.WriteLine("Enter New Info Of Student");
                Console.Write("First Name : ");
                string FirstName = Console.ReadLine();
                Console.Write("Last Name : ");
                string LastName = Console.ReadLine();
                Console.Write("CGPA : ");
                decimal CGPA = Convert.ToDecimal(Console.ReadLine());
                using (var context = new Context())
                {
                    Student stu = context.Students.Single(s => s.Rollno == roll);
                    if(FirstName != null)stu.FirstName = FirstName;
                    if (LastName != null) stu.LastName = LastName;
                    stu.CGPA = CGPA;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No Student Found");
            }
        }
        public static void      DeleteStudent(int roll)
        {
            try
            {
                using (var context = new Context())
                {
                    context.Students.Remove(ReturnStudent(roll));
                    context.SaveChanges();
                }
                Console.WriteLine("Successfully Deleted the Student");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Student Not Found");
            }
         
        }
        public static void      Addteacher()
        {
            Console.WriteLine("Enter Information of Teacher: ");
            Console.Write("Enter Teacher ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Teacher First Name: ");
            string FirstName = Console.ReadLine();
            Console.Write("Enter Teacher Last Name: ");
            string LastName = Console.ReadLine();

            Teacher Teacher = new Teacher(ID, FirstName, LastName);

            using (var context = new Context())
            {
                context.Teachers.Add(Teacher);
                context.SaveChanges();
            }

        }
        private static void     PrintInfo<T>(T obj)
        {
            Console.WriteLine("Description: ");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                
                Console.WriteLine("{0}  =   {1}", name, value);
            }
        }
        public static Student   ReturnStudent(int ID)
        {
            var student = new Student();
            using (var context = new Context())
            {
                student = context.Students.Single(b => b.Rollno == ID);
            }
            return student;
        }

    }
}
