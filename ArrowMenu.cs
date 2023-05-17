class ArrowMenu
{
	private Line line;
	private int width;
	public ArrowMenu(LineStyle lineStyle = LineStyle.THIN)
	{
		// Set the line style
		line = new Line(lineStyle);
	}


	public int Menu(string[] menuItems)
	{
		int index = 0;
		int padding = 5;
		int top = Console.CursorTop + 1;

		// Hide the cursor while the menu is active
		Console.CursorVisible = false;

		// Get the longest item in the menu
		int longest = 0;
		for (int i = 0; i < menuItems.Length; i++)
		{
			if (menuItems[i].Length > longest) longest = menuItems[i].Length;
		}
		width = (longest + (padding * 2));

		// Add the initial menu items
		Console.WriteLine(line.topLeft + new string(line.horizontal, width) + line.topRight);
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
			else if (input.Key == ConsoleKey.Enter)
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





// Line stuff
public enum LineStyle
{
	THIN,
	THICK,
	CLASSIC
}
class Line
{
	public char topLeft { get; }
	public char topRight { get; }
	public char bottomLeft { get; }
	public char bottomRight { get; }
	public char horizontal { get; }
	public char vertical { get; }

	public Line(LineStyle lineStyle)
	{
		if (lineStyle == LineStyle.THIN)
		{
			topLeft = '┌';
			topRight = '┐';
			bottomLeft = '└';
			bottomRight = '┘';
			horizontal = '─';
			vertical = '│';
		}
		else if (lineStyle == LineStyle.THICK)
		{
			topLeft = '╔';
			topRight = '╗';
			bottomLeft = '╚';
			bottomRight = '╝';
			horizontal = '═';
			vertical = '║';
		}
		else if (lineStyle == LineStyle.CLASSIC)
		{
			topLeft = '+';
			topRight = '+';
			bottomLeft = '+';
			bottomRight = '+';
			horizontal = '-';
			vertical = '|';
		}
	}
}