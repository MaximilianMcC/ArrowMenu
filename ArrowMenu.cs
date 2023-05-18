class ArrowMenu
{
	private MenuSettings settings;
	private int width;
	public ArrowMenu(MenuSettings settings)
	{
		// Add the settings to the menu
		this.settings = settings;
	}




	// Arrow menu without a title
	public int Menu(string[] menuItems)
	{
		return CreateMenu(menuItems);
	}

	// Arrow menu with a title
	public int Menu(string title, string[] menuItems)
	{
		return CreateMenu(menuItems, title);
	}






	private int CreateMenu(string[] menuItems, string title = "")
	{
		int index = 0;
		int top = Console.CursorTop + 1;
		int padding = settings.padding;
		Line line = settings.lineStyle;

		// Hide the cursor while the menu is active
		Console.CursorVisible = false;

		// Get the longest item in the menu
		int longest = title.Length;
		for (int i = 0; i < menuItems.Length; i++)
		{
			if (menuItems[i].Length > longest) longest = menuItems[i].Length;
		}
		width = (longest + (padding * 2));

		// If width is odd, make it even
		if (width % 2 != 0) width++;

		
		// Check for if there is a title supplied
		if (title != "")
		{
			// Add the top of the title area
			Console.WriteLine(line.topLeft + new string(line.horizontal, width) + line.topRight);
			
			// Add the title area
			string whitespace = new string(' ', (width - title.Length) / 2);
			Console.WriteLine(line.vertical + whitespace + title + whitespace + line.vertical);

			// Add the divider area
			Console.WriteLine(line.verticalLeftDivider + new string(line.horizontalDivider, width) + line.verticalRightDivider);

			// Update the top
			top += 2;
		}
		else Console.WriteLine(line.topLeft + new string(line.horizontal, width) + line.topRight);

		// Add the initial menu items
		Console.CursorTop = top + menuItems.Length;
		Console.WriteLine(line.bottomLeft + new string(line.horizontal, width) + line.bottomRight);
		Console.CursorTop = top;
		for (int i = 0; i < menuItems.Length; i++)
		{
			Console.SetCursorPosition(0, (top + i));
			DrawItem(menuItems[i], i == index);
		}


		// Menu loop
		while (true)
		{
			// Highlight the selected index
			for (int i = 0; i < menuItems.Length; i++)
			{
				// Draw the current menu item
				Console.SetCursorPosition(0, top + i);
				DrawItem(menuItems[i], i == index);
			}

			// Get the user input
			ConsoleKeyInfo input = Console.ReadKey(true);
			if (input.Key == ConsoleKey.UpArrow)
			{
				// Go up
				index--;
			}
			else if (input.Key == ConsoleKey.DownArrow || input.Key == ConsoleKey.Tab)
			{
				// Go down
				index++;
			}
			else if (input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Spacebar)
			{
				// Reset the cursor
				Console.SetCursorPosition(0, (top + menuItems.Length + 1));
				Console.CursorVisible = true;

				// Submit the current index as the answer
				return index;
			}

			// Check for if the new index is out of bounds
			if (index == -1) index = (menuItems.Length - 1);
			if (index == menuItems.Length) index = 0;
		}
	}


	private void DrawItem(string item, bool selected)
	{
		Line line = settings.lineStyle;


		// Draw the left border
		Console.Write(line.vertical);

		// Check for if the current item is selected
		if (selected == true)
		{
			// Flip the console colors
			ConsoleColor background = Console.BackgroundColor;
			Console.BackgroundColor = Console.ForegroundColor;
			Console.ForegroundColor = background;

			// Add a arrow thing
			Console.Write("> ");
		}
		else Console.Write("  ");

		// Add the text and whitespace, then revert the colors
		Console.Write(item);
		Console.Write(new string(' ', width - item.Length - 2));
		Console.ResetColor();

		// Draw the the right border
		Console.Write(line.vertical);
	}

}




class MenuSettings
{
	public Line lineStyle { get; set; }
	public int padding { get; set; }

	public MenuSettings(LineStyle lineStyle, int padding)
	{
		this.lineStyle = new Line(lineStyle);
		this.padding = padding;
	}
}







// Line stuff
public enum LineStyle
{
	THIN,
	THICK,
	CLASSIC,
	BLOCKY
}
class Line
{
	public char topLeft { get; }
	public char topRight { get; }
	public char bottomLeft { get; }
	public char bottomRight { get; }
	public char horizontal { get; }
	public char vertical { get; }
	public char verticalLeftDivider { get; set; }
	public char verticalRightDivider { get; set; }
	public char horizontalDivider { get; set; }

	public Line(LineStyle lineStyle)
	{
		//TODO: If another style is added, convert to switch statement
		if (lineStyle == LineStyle.THIN)
		{
			topLeft = '┌';
			topRight = '┐';
			bottomLeft = '└';
			bottomRight = '┘';
			horizontal = '─';
			vertical = '│';
			verticalLeftDivider = '├';
			verticalRightDivider = '┤';
			horizontalDivider = '─';
		}
		else if (lineStyle == LineStyle.THICK)
		{
			topLeft = '╔';
			topRight = '╗';
			bottomLeft = '╚';
			bottomRight = '╝';
			horizontal = '═';
			vertical = '║';
			verticalLeftDivider = '╟';
			verticalRightDivider = '╢';
			horizontalDivider = '─';
		}
		else if (lineStyle == LineStyle.CLASSIC)
		{
			topLeft = '+';
			topRight = '+';
			bottomLeft = '+';
			bottomRight = '+';
			horizontal = '-';
			vertical = '|';
			verticalLeftDivider = '+';
			verticalRightDivider = '+';
			horizontalDivider = '-';
		}
		else if (lineStyle == LineStyle.BLOCKY)
		{
			topLeft = '▒';
			topRight = '▒';
			bottomLeft = '▒';
			bottomRight = '▒';
			horizontal = '▒';
			vertical = '▒';
			verticalLeftDivider = '▒';
			verticalRightDivider = '▒';
			horizontalDivider = '░';
		}
	}
}