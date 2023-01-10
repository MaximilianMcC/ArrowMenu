ArrowMenu menu = new ArrowMenu()
{
    title = "Which of the above planets is largest?",
    menuItems = new[] { "Mercury", "Earth", "Jupiter", "Neptune" },
    decorationCharacters = 4,
    padding = 5
};


int answer = menu.VerticalMenu();

// Check for if they selected the correct answer
if (answer == 2) Console.WriteLine("Correct!");
else Console.WriteLine("Incorrect!");


// Stop the program from closing
Console.ReadKey();