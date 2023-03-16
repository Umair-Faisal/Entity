using System.Runtime.InteropServices;

namespace ConsoleAppUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start1:
            Console.WriteLine("Select A Number: ");
            Console.WriteLine("1. Add Student \n2.Find Student\n3.Update Student\n4.Delete Student");
            byte OP = 0;
            try { OP = Convert.ToByte(Console.ReadLine()); } catch (FormatException) { }
            Console.Clear();
            switch (OP)
            {
                case 1:
                    DataAccess.AddStudent();
                    break;
                case 2:
                    Console.Write("Enter RollNo. of Student: ");
                    int roll1 = Convert.ToInt32(Console.ReadLine());
                    DataAccess.GetStudent(roll1);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Write("Enter RollNo. of Student: ");
                    int roll2 = Convert.ToInt32(Console.ReadLine());
                    DataAccess.UpdateStudent(roll2);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Write("Enter RollNo. of Student: ");
                    int roll3 = Convert.ToInt32(Console.ReadLine());
                    DataAccess.DeleteStudent(roll3);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    Console.ReadKey();
                    break;
            }
            goto Start1;

            //DataAccess.SearchStudent();
            //DataAccess.AddStudent();
            //DataAccess.Addteacher();
            //DataAccess.UpdateStudent();
        }

            
    }
}