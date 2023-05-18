# Arrow Menu
This is a simple C# Library that can be used to create lists in a C# console program. These lists can be easily navigable using the arrow keys.

## About
Speed and looks are a priority in this library. There are different line styles that you can choose from. The characters are drawn very carefully with none being redrawn more than they need to, making the menu extremely fast.

## Documentation
1. **Create an arrow menu object.**
The arrow menu is initialized with the following line. You can also apply an optional settings option. The first argument is the line style, and the second in the padding. There are currently four different line styles.
```cs
// Create the arrow menu
ArrowMenu arrowMenu = new ArrowMenu();


// Example of using the classic line-style with 10 padding
MenuSettings settings = new MenuSettings(LineStyle.CLASSIC, 10);
ArrowMenu arrowMenu = new ArrowMenu(settings);
```

2. **Create an arrow menu**
Use the `ArrowMenu` object that you created in the previous step to run the `Menu` method. This method will return the index of the item submitted by the user. The method takes in one argument, a string array of menu items. You can also add a title if you want. To add a title, simply add a string as the first argument, with the options as the second.
```cs
// Create a string array of menu items
string[] options = new string[]
{
	"Option 1",
	"Option 2",
	"Option 3"
};

// Run the arrow menu and store the answer
int answer = arrowMenu.Menu(options);

// Run the arrow menu with a title, and store the answer
int answer = arrowMenu.Menu("Please select an option", options);
```