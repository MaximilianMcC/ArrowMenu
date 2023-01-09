string[] names = new string[] { "bob", "e", "Jeff", "James", "Robert", "John", "Test", "abcdefghijklmnopqrstuvwqyz" };

// Example usage of the vertical menu without a title
int selectedName1 = ArrowMenu.VerticalMenu(names);
Console.WriteLine("\n\nSelected name: " + selectedName1);


Console.WriteLine("\n\n\n\n\n\n");


// Example usage of the vertical menu with a title
int selectedName2 = ArrowMenu.VerticalMenu(names, "Select a person");
Console.WriteLine("\n\nSelected name: " + selectedName2);

//TODO: Example usage of the horizontal menu



// Stop the program from closing
Console.ReadKey();