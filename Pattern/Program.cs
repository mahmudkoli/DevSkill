using System;
using System.Collections.Generic;

namespace Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var university = new University("Dhanmondi");
            university.SetEstablish(2002);
            university.SetName("Daffodil");
            university.AddDepartment("CSE");
            university.AddDepartment("EEE");
            university.AddDepartment("SWE");

            Console.WriteLine($"Name: {university.Name}, Address: {university.Address}, Established: {university.Establish}");
            foreach (var item in university.Departments)
            {
                Console.WriteLine($"Department: {item}");
            }

            // Clone
            var newUniversity = university.Clone() as University;
            newUniversity.SetEstablish(2002);
            newUniversity.SetName("ULAB");
            newUniversity.AddDepartment("CSE");

            Console.WriteLine();
            Console.WriteLine($"Name: {newUniversity.Name}, Address: {newUniversity.Address}, Established: {newUniversity.Establish}");
            foreach (var item in newUniversity.Departments)
            {
                Console.WriteLine($"Department: {item}");
            }

        }
    }

    class University : ICloneable
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Establish { get; private set; }
        public List<string> Departments { get; private set; }

        public University(string address)
        {
            this.Address = address;
            this.Departments = new List<string>();
        }

        public University SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public University SetEstablish(int est)
        {
            this.Establish = est;
            return this;
        }

        public University AddDepartment(string depatment)
        {
            this.Departments.Add(depatment);
            return this;
        }

        public object Clone()
        {
            return new University(this.Address);
        }
    }
}
