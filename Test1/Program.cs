using IntExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Test1
{
    class Program
    {
        // creating delegate
        public delegate void GetSalary(List<Employee> employees);

        // implementations for delegate
        public static void GetLowestSalary(List<Employee> employees)
        {
            int lowestSalary = employees[0].Salary;
            foreach(Employee emp in employees)
            {
                if(emp.Salary < lowestSalary)
                {
                    lowestSalary = emp.Salary;
                }
            }
            Console.WriteLine($"The lowest salary among employees is {lowestSalary}");
        }

        public static void GetHighestSalary(List<Employee> employees)
        {
            int highestSalary = employees[0].Salary;
            foreach (Employee emp in employees)
            {
                if (emp.Salary > highestSalary)
                {
                    highestSalary = emp.Salary;
                }
            }
            Console.WriteLine($"The highest salary among employees is {highestSalary}");
        }

        static void Main(string[] args)
        {
            // 1 - Which Statement is correct? 
            // a. Properties of anonymous types will be read-only properties so you cannot change their values.

            // 2 

            Employee emp1 = new Employee(1, "Maria", 60000);
            Employee emp2 = new Employee(2, "John", 80000);
            Employee emp3 = new Employee(3, "Peter", 45000);
            Employee emp4 = new Employee(4, "Sylvia", 120000);
            Employee emp5 = new Employee(5, "Robert", 85000);

            List<Employee> employees = new List<Employee>() { emp1, emp2, emp3, emp4, emp5};

            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

            GetSalary lowest = GetLowestSalary;
            GetSalary highest = GetHighestSalary;

            lowest(employees);
            highest(employees);

            // 3 - Tuple

            Tuple<string, int, string> person = new Tuple<string, int, string>("Justin", 48, "Ottawa");

            Console.WriteLine("Hi, my name is {0}, I'm {1} years old, I'm from {2}", person.Item1, person.Item2, person.Item3);

            // 4 - Use Dictionary to keep the values of Information of 5 employees

            Hashtable hashEmployees = new Hashtable();

            foreach(Employee emp in employees)
            {
                hashEmployees.Add(emp.Id, emp.Name);
            }

            foreach(DictionaryEntry entry in hashEmployees)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }

            // 5 - Create a Generic Class the only accepts class reference

            // -->> MyGenericClass

            MyGenericClass<Employee> employeeClass = new MyGenericClass<Employee>();
            // MyGenericClass<int> intClass = new MyGenericClass<int>(); --> this one has an error since it's not a class type

            // 6 - Use Extension method for integer to check if the number is dividable by 3 

            int a = 8;
            int b = 15;
            Console.WriteLine(a.isDividableBy3());
            Console.WriteLine(b.isDividableBy3());

            // 7 - Write a method that has one string parameter. By Using predicate check if that string has vowel sounds and print all the vowel sounds in the output. 

            Predicate<char> IsVowel = delegate (char c)
            {
                List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
                foreach (char vowel in vowels)
                {
                    if (char.ToLower(c) == char.ToLower(vowel))
                    {
                        return true;
                    }
                }
                return false;

            };

            void FindVowels(string str)
            {
                char[] charArr = str.ToCharArray();
                StringBuilder result = new StringBuilder();
                foreach(char ch in charArr)
                {
                    if (IsVowel(ch))
                    {
                        result.Append(ch);
                    }
                }
                Console.WriteLine(result);
            }

            FindVowels("Hello, this is my test string");



        }
    }
}
