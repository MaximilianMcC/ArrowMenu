// Example of a vertical menu with a title
string[] options = new string[] { "Mercury", "Earth", "Jupiter", "Neptune" };
int answer = ArrowMenu.VerticalMenu(options, "Which of the above planets is largest?");

// Check for if they selected the correct answer
if (answer == 2) Console.WriteLine("Correct!");
else Console.WriteLine("Incorrect!");


// Stop the program from closing
Console.ReadKey();