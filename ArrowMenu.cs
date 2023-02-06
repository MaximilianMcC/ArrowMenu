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
	string[] menuItems { get; set; }
	MenuStyle menuStyle { get; set; }


	// Constructor that makes a new arrow menu
	public ArrowMenu(MenuStyle menuStyle, string[] menuItems, string title)
	{
		this.menuItems = menuItems;
		this.menuStyle = menuStyle;
	}


	public static int Menu()
	{
		
		
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