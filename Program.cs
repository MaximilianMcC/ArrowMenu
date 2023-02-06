// Make a menu style
MenuStyle menuStyle = new MenuStyle();
menuStyle.prefix = "->";
menuStyle.lineStyle = LineStyle.THICK;

// Make an arrow menu
string[] menuItems = new string[]
{
    "Option 1",
    "Option 2",
    "Option 3",
    "Option 4",
    "Option 5"
};
ArrowMenu arrowMenu = new ArrowMenu(menuStyle, new[] {"e"}, "e");


// Stop the program from closing
Console.ReadKey();