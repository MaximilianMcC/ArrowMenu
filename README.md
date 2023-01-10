# 📰 **ArrowMenu**
Arrow menu helps you make simple ascii art lists that can be navigated using the arrow keys on your keyboard.


## 🤓 *Example usage*

# ArrowMenu Class documentation

This class creates a vertical menu that can be displayed on the console, with a title and multiple menu items. The user can navigate through the menu using the up and down arrow keys, and select an option using the enter key. The class also allows for customizing the decoration characters and padding of the menu. 

## Properties

The class has the following properties:

- `title` (string): The title of the menu that will be displayed at the top of the menu.

- `menuItems` (string[]): The items that will be displayed in the menu.

- `decorationCharacters` (int): The number of characters to use for the decoration.

- `padding` (int): The amount of padding to use for each menu item.

## Methods

The class has the following method:

- `VerticalMenu()`: This method displays the menu on the console and returns the index of the selected item.

## Example
```cs
// Create an instance of the ArrowMenu class
ArrowMenu menu = new ArrowMenu()
{
title = "Which of the above planets is largest?",
menuItems = new[] { "Mercury", "Earth", "Jupiter", "Neptune" },
decorationCharacters = 4,
padding = 5
};

// Show the menu and get the selected index
int answer = menu.VerticalMenu();

// Check for if they selected the correct answer
if (answer == 2) Console.WriteLine("Correct!");
else Console.WriteLine("Incorrect!");
```
Note that the above example code creates an instance of the `ArrowMenu` class and sets the `title`, `menuItems`, `decorationCharacters`, and `padding` properties. It then calls the `VerticalMenu()` method to display the menu on the console and gets the selected index. The selected index can then be used to check if the correct option was selected.