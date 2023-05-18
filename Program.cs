class Program
{
    
    public static void Main(string[] args)
    {
        // Create an array of different options
        string[] options = new string[]
        {
            "Option 1",
            "Option 2",
            "Option 3",
            "Option 4",
            "Option 5"
        };

        // Make an arrow menu with settings
        MenuSettings settings = new MenuSettings(LineStyle.CLASSIC, 10);
        ArrowMenu arrowMenu = new ArrowMenu(settings);

        // Run the menu and get the answer
        int answer = arrowMenu.Menu("Test 123", options);
        Console.WriteLine("Answer: " + (answer + 1));


        Console.ReadKey();
    }
}