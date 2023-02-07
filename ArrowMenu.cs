class MenuStyle
{
	/// <summary>
	/// Characters that will be placed before the current menu item.
	/// </summary>
	public string prefix { get; set; }

	/// <summary>
	/// The line style of the menu.
	/// </summary>
	public LineStyle lineStyle;

	/// <summary>
	/// Should the menu spawn the entire width of the console.
	/// </summary>
	public bool fullWidth;
}

enum LineStyle
{
	/// <summary>
	/// Thick lines such as "═══"
	/// </summary>
	THICK,

	/// <summary>
	/// Thin lines such as "───"
	/// </summary>
	THIN
}


class ArrowMenu
{
	string[] menuItems;
	MenuStyle menuStyle;


	// Constructor that makes a new arrow menu
	public ArrowMenu(MenuStyle menuStyle, string[] menuItems, string title)
	{
		this.menuItems = menuItems;
		this.menuStyle = menuStyle;
	}


	public int Menu()
	{
		int index = 0;
		int menuTop = Console.CursorTop + 1;
		int menuWidth = 0;


		// Draw the menu borders
		if (menuStyle.fullWidth == true)
		{
			DrawBox(Console.WindowWidth - 1, menuItems.Length);

			// Assign the inner menu width
			menuWidth = Console.WindowWidth - 3;
		}
		else
		{
			// Calculate the total width of the menu
			int menuBoxWidth = menuItems.Max(menuItem => menuItem.Length);

			// Apply padding and prefix
			menuBoxWidth += 10;
			menuBoxWidth += menuStyle.prefix.Length;

			// Draw the menu borders
			DrawBox(menuBoxWidth, menuItems.Length);

			// Assign the inner menu width
			menuWidth = menuBoxWidth - 2;
		}
		

		// Add in all of the menu items
		while (true)
		{

			// Loop over all menu items
			for (int i = 0; i < menuItems.Length; i++)
			{
				// Set the correct cursor position
				Console.SetCursorPosition(1, menuTop + i);

				// Check for if the current one is selected, else draw it normally
				if (index == i)
				{
					// Switch the colors
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;

					// Add the background color thing
					Console.Write(new string(' ', menuWidth));

					// Add the menu item
					Console.SetCursorPosition(1, Console.CursorTop);
					Console.Write(menuStyle.prefix + menuItems[i]);
				}
				else Console.Write(new string(' ', menuStyle.prefix.Length) + menuItems[i]);


				// Set the colors back to the original
				Console.ResetColor();
			}

			break;
		}


		return 0;
	}










	void DrawBox(int width, int height)
	{
		// Trim the width to take into account the sides
		width -= 2;

		// Get the line style
		//TODO: Don't use empty character
		char topLeft = '\0';
		char topRight = '\0';
		char bottomLeft = '\0';
		char bottomRight = '\0';
		char horizontal = '\0';
		char vertical = '\0';

		// Assign the line style
		if (menuStyle.lineStyle == LineStyle.THICK)
		{
			topLeft = '╔';
			topRight = '╗';
			bottomLeft = '╚';
			bottomRight = '╝';
			horizontal = '═';
			vertical = '║';
		}
		else if (menuStyle.lineStyle == LineStyle.THIN)
		{
			topLeft = '┌';
			topRight = '┐';
			bottomLeft = '└';
			bottomRight = '┘';
			horizontal = '─';
			vertical = '│';
		}


		// Draw the top of the box
		Console.WriteLine(topLeft + new string(horizontal, width) + topRight);
		
		// Draw the middle/walls of the box
		for (int i = 0; i < height; i++)
		{
			Console.WriteLine(vertical + new string(' ', width) + vertical);
		}

		// Draw the bottom of the box
		Console.WriteLine(bottomLeft + new string(horizontal, width) + bottomRight);

	}
}