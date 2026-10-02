using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using C_story_path_game.Models;

namespace C_story_path_game
{
    // Represents the players processed choice result
    public struct ChoiceResult
    {
        public bool IsValid { get; set; }
        public int SelectedIndex { get; set; }

        public ChoiceResult(bool isValid, int selectedIndex)
        {
            IsValid = isValid;
            SelectedIndex = selectedIndex;
        }
    }

    // Engine class that manages story loading, gameplay loop, and file manipulation
    public class GameEngine
    {
        private readonly string _filePath = Path.Combine("Data", "story.json");
        private readonly string _logFilePath = "game_log.txt";
        private Dictionary<string, NarrativeNode> _nodes = new Dictionary<string, NarrativeNode>();
        private string _currentNodeId = "1";

        // Function to load the story from the JSON file
        public void LoadStory()
        {
            // Validate file existence
            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"Error: File not found at {_filePath}");
                return;
            }

            // Read all content from the file
            string jsonContent = File.ReadAllText(_filePath);

            // Deserialization from JSON into C# object list
            List<NarrativeNode>? nodeList = JsonSerializer.Deserialize<List<NarrativeNode>>(jsonContent);

            if (nodeList != null)
            {
                //Populate nodes dictionary using node ID as key
                foreach (NarrativeNode node in nodeList)
                {
                    _nodes[node.Id] = node;
                }
            }

            // Initialize log file for the current session
            File.WriteAllText(_logFilePath, $"--- New Game Started: {DateTime.Now} ---\n");
        }

        //Main game loop execution
        public void Start()
        {
            LoadStory();

            if (_nodes.Count == 0)
            {
                Console.WriteLine("Failed to load story nodes. Exiting game.");
                return;
            }

            bool isRunning = true;

            // Game loop that continues until an ending node is reached
            while (isRunning)
            {
                if (!_nodes.ContainsKey(_currentNodeId))
                {
                    Console.WriteLine($"Error: Node ID '{_currentNodeId}' missing from story graph.");
                    break;
                }

                NarrativeNode currentNode = _nodes[_currentNodeId];

                // Display current narrative node
                DisplayNode(currentNode);

                // Log current node visit in the txt file
                LogPlayerProgress(currentNode.Id);

                //Check if node is an ending (empty or null)
                if (currentNode.Options == null || currentNode.Options.Count == 0)
                {
                    Console.WriteLine("\n--- THE END ---");
                    File.AppendAllText(_logFilePath, "--- Game Ended ---\n");
                    isRunning = false;
                }
                else
                {
                    // Function to process player input
                    ChoiceResult result = GetPlayerChoice(currentNode.Options.Count);

                    if (result.IsValid)
                    {
                        //if result is valid move to target node
                        Option chosenOption = currentNode.Options[result.SelectedIndex];
                        _currentNodeId = chosenOption.TargetId;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Press ENTER to try again.");
                        Console.ReadLine();
                    }
                }
            }
        }

        // Function to display story text and options
        private void DisplayNode(NarrativeNode node)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine(node.Text);
            Console.WriteLine("==================================================");

            if (node.Options != null && node.Options.Count > 0)
            {
                Console.WriteLine("\nWhat will you do?\n");
                // Loop through options to display numbered choices
                for (int i = 0; i < node.Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {node.Options[i].Text}");
                }
            }
        }

        // Function to get and validate user input from console using Structure
        private ChoiceResult GetPlayerChoice(int optionsCount)
        {
            Console.Write("\nEnter option number: ");
            string? input = Console.ReadLine();

            // parsing and validate range
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= optionsCount)
            {
                return new ChoiceResult(true, choice - 1);
            }

            return new ChoiceResult(false, -1);
        }

        // Append current node to log file
        private void LogPlayerProgress(string nodeId)
        {
            File.AppendAllText(_logFilePath, $"Player reached Node: {nodeId}\n");
        }
    }
}