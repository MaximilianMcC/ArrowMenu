# 📰 **ArrowMenu**
Arrow menu helps you make simple ascii art lists that can be navigated using the arrow keys on your keyboard.


## 🤓 *Example usage*
First, add the `ArrowMenu` class to your project.

To make an arrow menu you must have data to display in it. The menu items should be an a 1D string array. The arrow menus selection will return the index of this array. Here is an example of the data array
```cs
string[] options = new string[] { "Mercury", "Earth", "Jupiter", "Neptune" };
```

To create the actual arrow menu you must make a new int to store the answer. Call the arrow menu method that you need, and pass in the array we created above. Here is an example of making a menu:
```cs
int answer = ArrowMenu.VerticalMenu(options);
```
<details><summary>Example output</summary>

```
╔═══════════════════════════════════════════════╗
║ > Mercury                                     ║
║   Earth                                       ║
║   Jupiter                                     ║
║   Neptune                                     ║
╚═══════════════════════════════════════════════╝
```
</details>

You can also optionally include a string for a title. Here is an example of making a menu with a title:
```cs
int answer = ArrowMenu.VerticalMenu(options, "Which of these above planets is largest?");
```
<details><summary>Example output</summary>

```
╔═══════════════════════════════════════════════╗
║Which of the above planets is largest?         ║
╟───────────────────────────────────────────────╢
║ > Mercury                                     ║
║   Earth                                       ║
║   Jupiter                                     ║
║   Neptune                                     ║
╚═══════════════════════════════════════════════╝
```
</details>


The user can interact with the menu by using the arrow keys to move up and down. When they have selected the option that they want, pressing the enter key will submit the menu. Here is a full example of using an arrow menu:
```cs
// Make the menu
string[] options = new string[] { "Mercury", "Earth", "Jupiter", "Neptune" };
int answer = ArrowMenu.VerticalMenu(options, "Which of these planets is largest?");

// Check for if they selected the correct answer
if (answer == 2) Console.WriteLine("Correct!");
else Console.WriteLine("Incorrect!");
```