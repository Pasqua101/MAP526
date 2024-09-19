class MyProgram
{
    static void Main(String[] args)
    {
        /*Console.WriteLine("Hello World!");*/

        /*MyProgram p = new MyProgram();
        p.sum();

        sum2(3, 5);

        Console.WriteLine($"SUM3: {sum3()}");

        Console.WriteLine($"SUM4: {sum4(2, 3)}");*/

        Employee emp1 = new Employee("Alex");

        emp1.showEmployeeDetails();

        showNumberOfYears(emp1.name, emp1.getNumYearsWorked());

        // update the values of emp1
        emp1.name = "Smith";
        // Note: Only name is updated, since we explicitly updated the name. We did not call the constructor, so nothing would change other than the name
        emp1.yearHired = 1970;

        emp1.showEmployeeDetails();
        showNumberOfYears(emp1.name, emp1.getNumYearsWorked());

        Employee emp2 = new Employee("Sara", "sara@company.com", 1990);
        emp2.showEmployeeDetails();
        
    }

    static void showNumberOfYears(string name, int years)
    {
        if (years == -1)
        {
            Console.WriteLine("Something went wrong. Please check if you have the right hired year.");
        }
        else
        {
            Console.WriteLine($"{name} has been an employee for {years} years");
        }
    }

    // 1. no parameters
    // if we make this a static function, it'll become a class function so we'll won't have to make an instance of MyProgram to call this function. Ex, we can just use sum(), without doing p.sum()
    // However, if we do this, then we cannot access the function in an instance. Since it'll be shared between all instances of MyProgram
    void sum()
    {
        int a = 15;
        int b = 25;
        int results = a + b;
        Console.WriteLine($"The sum of {a} and {b} is {results}");
    }

    // 2. with parameters
    static void sum2(int a, int b)
    {
        int result = a + b;
        Console.WriteLine($"SUM2:  The sum of {a} and {b} is {result}");
    }

    // value returning functions
    // 3. no parameters
    static int sum3()
    {
        int a = 5;
        int b = 10;
        int result = a + b;
        return result;
    }

    // 4. with parameters
    static int sum4(int a, int b)
    {
        int result = a + b;
        return result;
    }

}

