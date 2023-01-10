class ArrowMenu
{
	public string title { get; set; }
	public int padding { get; set; }
	public int decorationCharacters { get; set; }
	public string[] menuItems { get; set; }



	public int VerticalMenu()
	{
		// Menu properties
		int menuIndex = 0;

		// Get the total width of the menu
		int menuWidth = title.Length;
		foreach (string item in menuItems) if (item.Length > menuWidth) menuWidth = item.Length;
		menuWidth += (decorationCharacters + padding);

		// Get the position of all of the menu items
		int menuItemsPosition = Console.GetCursorPosition().Top;



		// Add the top part of the menu
		Console.WriteLine('╔' + new string('═', menuWidth) + '╗');

		// Add the title if there is one
		if (title != "")
		{
			Console.WriteLine($"║   {title}{new string(' ', menuWidth - (title.Length + decorationCharacters))} ║");
			Console.WriteLine('╟' + new string('─', menuWidth) + '╢');
			menuItemsPosition += 2;
		}

		// Add the bottom part of the menu
		Console.SetCursorPosition(Console.CursorLeft, (menuItemsPosition + menuItems.Length + 1));
		Console.WriteLine('╚' + new string('═', menuWidth) + '╝');




		while (true)
		{
			// Set the cursor position of the top of all of the menu items so the entire screen doesn't need to be cleared
			Console.SetCursorPosition(Console.CursorLeft, menuItemsPosition);


			// Add all of the menu items
			for (int i = 0; i < menuItems.Length; i++)
			{
				// Move on to the next menu item
				Console.SetCursorPosition(Console.CursorLeft, menuItemsPosition + (i + 1));



				// Generate the whitespace for the current menu item
				string whitespace = new string(' ', menuWidth - (menuItems[i].Length + decorationCharacters));



				// Highlight the selected menu item
				if (i == menuIndex)
				{
					Console.Write("║ > ");

					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
					Console.Write(menuItems[i] + whitespace);
					Console.ResetColor();

					Console.WriteLine(" ║");
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
			else if (input.Key == ConsoleKey.Enter) {

				// Give back the selected answer
				Console.WriteLine();
				return menuIndex;
			}

			// Check for if the menuIndex is out of bounds
			if (menuIndex > menuItems.Length - 1) menuIndex = 0;
			else if (menuIndex < 0) menuIndex = menuItems.Length - 1;
		}
	}
}