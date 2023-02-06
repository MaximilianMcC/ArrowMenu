# 📰 **ArrowMenu**
Arrow menu helps you make simple ascii art lists that can be navigated using the arrow keys on your keyboard.


## Documentation
To create an arrow menu, two objects are needed. First a `MenuStyle`, then the actual `ArrowMenu`. The point of having the menu style separate is you can apply it to multiple menus, or have multiple styles at the same time.

```cs
// Create a menu style
MenuStyle menuStyle = new MenuStyle();

// Change the prefix and width
menuStyle.prefix = "{i})";
menuStyle.fullWidth = true;
```