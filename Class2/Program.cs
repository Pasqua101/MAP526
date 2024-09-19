// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Declaring variables
int x = 25;
int y = 50;
int sum = x + y;

// Output to the console
Console.WriteLine("Hello world!");
Console.WriteLine(x);
Console.WriteLine(y);
Console.WriteLine(sum);


// String interpolation vs String concatenation

// String concatenation
Console.WriteLine("The sum of " + x + " and " + y + " is " + (x + y));

//String interpolation
Console.WriteLine($"The sum of {x} and {y} is {x + y}");
Console.WriteLine($"The difference of {x} and {y} is {x - y}");

// Reassigning variables
x = 100;
Console.WriteLine($"The sume of {x} and {y} is {x + y}");

// Of course if we did x = "Hello world"; it would produce an error since we cannot convert a string to an int

//Declaring double values
int radius = 10;
double area = radius * radius * Math.PI;
Console.WriteLine($"The area of a circle with the radius {radius} is {area}");


// Formatting the output of decimals
// format the string to specified decimal points
Console.WriteLine("Area to 2 decimal points: " + area.ToString("0.00"));
Console.WriteLine("Area to 3 decimal points: " + area.ToString("0.000"));
Console.WriteLine("Area to 4 decimal points: " + area.ToString("0.0000"));

// Working with Strings
string name = "     Peter Smith     ";
Console.WriteLine(name);

// Removing whitespace from the string

// remove leading whitespace
Console.WriteLine($"{name.TrimStart()}!");

// remove trailing whitespace
Console.WriteLine($"{name.TrimEnd()}!");

// Remove both leading and trailing
Console.WriteLine($"{name.Trim()}!");

// Replacing text
string updatedName = name.Replace("Smith", "Jones");
Console.WriteLine(updatedName + "!");

// Formatting string with upper and lower case
string city = "Montreal";
Console.WriteLine(city.ToUpper());
Console.WriteLine(city.ToLower());

// Search for substrings
// This is case sensitive
string phrase = "This is the way!";
Console.WriteLine("Does the sentence contain the word apple? " + phrase.Contains("apple"));
Console.WriteLine("Does the sentence contain the word way? " + phrase.Contains("way"));

// Conditionals
int grade = 50;
if (grade < 50)
{
    Console.WriteLine("You did not pass the test");
}
else
{
    Console.WriteLine("You passed the test!");
}

double gpa = 3.0;
if (gpa == 4.0)
{
    Console.WriteLine("A");
} else if (gpa > 2.8 &&  gpa <= 3.9)
{
    Console.WriteLine("B");
} else if (gpa == 1.0 || gpa < 2.5)
{
    Console.WriteLine("C");
} else
{
    Console.WriteLine("Invalid GPA");
}

// Loops
// while loop
int count = 4;
while (count >= 0)
{
    Console.WriteLine($"Counting down from {count}");
    count = count - 1;
}

Console.WriteLine("-------");

// for loop

for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine($"Even number {i}");
    }
}

// Working with Lists
// - Size of lists automatically grows and shrinks based on num of items in it
// - Can iterate through a list using foreach loop

List<string> fruits = new List<string>() { "apple", "banana", "carrot" };

// Get num of items in the list
Console.WriteLine($"Number of fruits: {fruits.Count}");

// Add items to the list
fruits.Add("donut");
fruits.Add("eggplant");
Console.WriteLine($"Number of fruits: {fruits.Count}");

// Getting an item by position
Console.WriteLine($"Item at position 0: {fruits[0]}");

// Looping through a list and printing each item
for (int i = 0; i < fruits.Count; i++)
{
    Console.WriteLine($"Fruit at pos {i} is {fruits[i]}");
}

// Using a foreach loop to print each item
foreach (string item in fruits)
{
    Console.WriteLine(item);
}
Console.WriteLine("-------");

// Getting the last item in the list
string lastItem = fruits[fruits.Count - 1];
Console.WriteLine($"Last item in the list: {lastItem}");

// Updating an item in the list
fruits[0] = "avocado";
Console.WriteLine($"Item at position 0: {fruits[0]}");

// Searching for an item
// - if item exists in the list .IndexOf returns the position number of the item
// - Otherwise, .IndexOf returns -1

Console.WriteLine($"Where is carrot? {fruits.IndexOf("carrot")}");
Console.WriteLine($"Where is orange? {fruits.IndexOf("orange")}");

// Reversing the list
fruits.Reverse();
// print all items in the list
foreach (string item in fruits)
{
    Console.WriteLine(item);
}
Console.WriteLine("-------");

// Sorting the list in alphabetical order
fruits.Sort();
foreach (string item in fruits)
{
    Console.WriteLine(item);
}

// Removing the item at a specific position
Console.WriteLine("-------");

fruits.RemoveAt(0);

foreach (string item in fruits)
{
    Console.WriteLine(item);
}

// removing all items from the list
fruits.Clear();
Console.WriteLine($"Number of items in the list: {fruits.Count}");