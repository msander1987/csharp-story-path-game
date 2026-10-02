# Overview

My goal with this project is to improve my C# programming skills and learn how to build a well-structured application from scratch. I wanted to challenge myself to create something interactive while applying core C# concepts like object-oriented programming, data handling, and file management.

I wrote a text-based adventure game that runs in the terminal. Instead of hardcoding the story inside the C# code, the game reads the story structure from an external json file. The engine loads these scenes into memory, lets the player make choices through the console, and updates a text log file in real time to keep track of the player's choices and story path.

I created this project to practice essential C# concepts like classes, structs, lists, dictionaries, reading/writing files, and converting JSON data into C# objects. It was a great way to learn how to keep my code clean, organized, and decoupled.

[Software Demo Video](https://youtu.be/hc231BQGIvs)

# Development Environment

To write and test this project, I used the following development tools:

- **Visual Studio Code**: My main editor for writing, formatting, and debugging the C# code.
- **Git & GitHub**: Used for version control to save my progress and manage the project repository.
- **Terminal / .NET CLI**: Used the `dotnet run` and `dotnet build` commands to compile and run the game.

**Language & Libraries:**
- **C# (.NET 8.0 SDK)**: The main programming language used for the game.
- **`System.Text.Json`**: Used to read the `story.json` file and convert it into C# objects.
- **`System.IO`**: Used to read files and write the player's progress into `game_log.txt`.
- **`System.Collections.Generic`**: Used for lists (`List<T>`) to store choices and dictionaries (`Dictionary<K, V>`) to quickly look up story scenes by their ID.

# Useful Websites

- [Microsoft C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)
- [JSON Deserialization in C# - Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to)
- [Wikipedia C Sharp](https://en.wikipedia.org/wiki/C_Sharp_(programming_language))
- [C# Structs vs Classes - W3Schools](https://www.w3schools.com/cs/cs_struct.php)

# Future Work

- Add a save/load feature so players can save their game and continue later.
- Add colored text to the console to make the story feel more immersive.
- Add sounds and effects to make the story feel more exciting.
- Save more than one game session in the log text file and create a line stating how many times the game was played.