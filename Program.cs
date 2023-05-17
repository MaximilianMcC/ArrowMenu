class Program
{
    
    public static void Main(string[] args)
    {

        string[] options = new string[]
        {
            "Option 1",
            "Option 2",
            "Option 3",
            "Option 4",
            "Option 5"
        };
        ArrowMenu arrowMenu = new ArrowMenu(LineStyle.THICK);
        int answer = arrowMenu.Menu(options);
        Console.WriteLine("Answer: " + (answer + 1));


        Console.ReadKey();
    }
}