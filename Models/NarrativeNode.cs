using System.Collections.Generic;

namespace C_story_path_game.Models
{
    // Represents a single story scene/node in the game
    public class NarrativeNode
    {
        // Unique identifier for the node
        public string Id { get; set; }

        // Narrative content displayed
        public string Text { get; set; }

        // List of available options for this node
        public List<Option> Options { get; set; }
    }
}