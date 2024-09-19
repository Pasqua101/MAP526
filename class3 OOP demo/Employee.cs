using System;

// definition of a custom data type (class) called Employee
public class Employee
{
    // field (attributes)
    // attributes will not be visible in other classes if they are not `public`


    /*private string _name;
    public string email;
    public int yearHired = 2015; // field with initial value*/

    // This method below is very similar to using something like _name and public string name.
    public string name { get; set; }
    public string email { get; set; }
    public int yearHired { get; set; } = 2015;
    

    /*public string name
    {
        get
        {
            return this._name;
        }
        set
        {
            this._name = value;
        }
    }*/

    // initializer (constructor)
    public Employee(string name)
    {
        this.name = name;
        this.email = $"{this.name}@mycompany.com";
    }

    public Employee(string name, string email, int yearHired)
    {
        this.name = name;
        this.email = email;
        this.yearHired = yearHired;
    }

    // methods (behaviour)

    public void showEmployeeDetails ()
    {
        Console.WriteLine("|------------------------------|");
        Console.WriteLine($"| EMPLOYEE NAME: {this.name}");
        Console.WriteLine($"| EMPLOYEE EMAIL: {this.email}");
        Console.WriteLine($"| EMPLOYEE SINCE: {this.yearHired}");
        Console.WriteLine("|------------------------------|");
    }

    // method that returns a value
    public int getNumYearsWorked()
    {
        // 1. Get the current year
        DateTime today = DateTime.Now;
        int currYear = today.Year;

        // 2. error handling
        // check if the dateHired is in the future or before 1980 (company est. year)
        if (currYear > this.yearHired && this.yearHired >= 1980)
        {
            // 3. Difference between the current year and the hired year
            int yearsWorked = currYear - this.yearHired;

            // 4. Return the difference
            return yearsWorked;
        }

        return -1;
    }

    // setting method -- name
    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return this.name;
    }
}