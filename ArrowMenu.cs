class ArrowMenu
{
	//TODO: Also get string lists and char lists/arrays and stuff
	//TODO: Add comments saying what all of the random numbers are
	public static int VerticalMenu(string[] menuItems, string title = "")
	{
		// Menu properties
		int menuIndex = 0;
		int menuPadding = 5;
		int decorationCharacters = 4; //? Stuff like the walls, and arrow thats shows the selected item

		// Get the total width of the menu
		int menuWidth = title.Length;
		foreach (string item in menuItems) if (item.Length > menuWidth) menuWidth = item.Length;
		menuWidth += decorationCharacters + menuPadding;

		// Get the position of all of the menu items
		int menuItemsPosition = Console.GetCursorPosition().Top;



		// Add the top part of the menu
		Console.WriteLine('╔' + new string('═', menuWidth) + '╗');

		// Add the title if there is one
		if (title != "")
		{
			Console.WriteLine($"║{title}{new string(' ', menuWidth - title.Length)}║");
			Console.WriteLine('╟' + new string('─', menuWidth) + '╢');
			menuItemsPosition += 2;
		}

		// Add the bottom part of the menu
		Console.SetCursorPosition(Console.CursorLeft, (menuItemsPosition + menuItems.Length + 1));
		Console.WriteLine('╚' + new string('═', menuWidth) + '╝');


		while (true)
		{
			Console.SetCursorPosition(Console.CursorLeft, menuItemsPosition);


			// Add all of the menu items
			for (int i = 0; i < menuItems.Length; i++)
			{
				Console.SetCursorPosition(Console.CursorLeft, menuItemsPosition + (i + 1));


				// Generate the whitespace for the current menu item
				string whitespace = new string(' ', menuWidth - (menuItems[i].Length + decorationCharacters));


				// Highlight the selected menu item
				if (i == menuIndex)
				{
					Console.WriteLine($"║ > {menuItems[i]}{whitespace} ║");
				}
				else
				{
					Console.WriteLine($"║   {menuItems[i]}{whitespace} ║");
				}
			}

			// Get input
			ConsoleKeyInfo input = Console.ReadKey(true);

			// Check for what has been pressed
			if (input.Key == ConsoleKey.DownArrow) menuIndex++;
			else if (input.Key == ConsoleKey.UpArrow) menuIndex--;
			else if (input.Key == ConsoleKey.Enter) return menuIndex;

			// Check for if the menuIndex is out of bounds
			if (menuIndex > menuItems.Length - 1) menuIndex = 0;
			else if (menuIndex < 0) menuIndex = menuItems.Length - 1;
		}
	}

}