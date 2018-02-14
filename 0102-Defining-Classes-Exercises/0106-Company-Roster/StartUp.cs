﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class StartUp
{
    static void Main()
    {
        var departments = new List<Department>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var args = Console.ReadLine().Split();

            Employee employee = FillEmployeeInfo(args);

            string departmentName = args[3];

            var department = departments.FirstOrDefault(d => d.Name == departmentName);

            if (department == null)
            {
                var newDep = new Department(departmentName);
                newDep.AddEmployee(employee);
                departments.Add(newDep);
            }
            else
            {
                department.AddEmployee(employee);
            }
        }

        PrintResult(departments);
    }

    private static Employee FillEmployeeInfo(string[] args)
    {
        var employee = new Employee()
        {
            Name = args[0],
            Salary = decimal.Parse(args[1]),
            Position = args[2]
        };
        if (args.Length == 5)
        {
            employee.Email = args[4];
        }
        else if (args.Length == 6)
        {
            employee.Email = args[4];
            employee.Age = int.Parse(args[5]);
        }

        return employee;
    }

    private static void PrintResult(List<Department> departments)
    {
        var result = departments
            .OrderByDescending(x => x.CalculateAverage())
            .FirstOrDefault();

        Console.WriteLine($"Highest Average Salary: {result.Name}");

        foreach (var employee in result.Employees.OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} " +
                $"{employee.Email} {employee.Age}");
        }
    }
}
