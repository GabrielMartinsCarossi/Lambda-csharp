using System;
using Course_Lambda.Entities;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Course_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();


            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));

                }
            }

            Console.Write("Enter salary filer: $");
            double salaryFilter = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //var filter = list.Where(e => e.Salary > salaryFilter).OrderBy(e => e.Email).Select(e => e.Email);

            var filteredList =
                from e in list
                where e.Salary > salaryFilter
                orderby e.Email
                select e.Email;

            Console.WriteLine("Results: " + filteredList.Count());

            foreach (string email in filteredList)
            {
                Console.WriteLine(email);
            }
               
        }
    }
}
