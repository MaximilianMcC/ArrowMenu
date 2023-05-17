# Arrow Menu
This is a simple C# Library that can be used to create lists in a C# console program. These lists can be easily navigable using the arrow keys.

## About
Speed and looks are a priority in this library. There are different line styles that you can choose from. The characters are drawn very carefully with none being redrawn more than they need to, making the menu extremely fast.

## Documentation
1. **Create an arrow menu object.**
These arrow menu objects have have an optional line style supplied. Currently, you can choose from *thin*, *thick*, or *classic*.
```cs
// Has a default of thin line style
ArrowMenu arrowMenu = new ArrowMenu();                

// Changing line styles
ArrowMenu arrowMenu = new ArrowMenu(LineStyle.THIN);
ArrowMenu arrowMenu = new ArrowMenu(LineStyle.THICK);
ArrowMenu arrowMenu = new ArrowMenu(LineStyle.CLASSIC);
```

2. **Create an arrow menu**
Use the `ArrowMenu` object that you created in the previous step to run the `Menu` method. This method will return the index of the item submitted by the user. The method takes in one argument, a string array of menu items.
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
```