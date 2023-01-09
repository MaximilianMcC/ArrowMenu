class ArrowMenu
{
	//TODO: Also get string lists and char lists/arrays and stuff
	//TODO: Add comments saying what all of the random numbers are
	public static int VerticalMenu(string[] menuItems, string title = "")
	{
		// Menu properties
		int menuIndex = 0;

		// Add the title if there is one
		if (title != "")
		{
			Console.WriteLine(title);
		}


		while (true)
		{			
			// Add all of the menu items
			for (int i = 0; i < menuItems.Length; i++)
			{
				// Highlight the selected menu item
				if (i == menuIndex)
				{
					Console.WriteLine("> " + menuItems[i]);
				}
				else
				{
					Console.WriteLine("  " + menuItems[i]);
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


			//TODO: Use an alternative method of clearing the console
			Console.Clear();
		}
	}

}