namespace C_story_path_game.Models
{
    // Represents a single option of a narrative node
    public class Option
    {
        // Display text shown to the player for this choice
        public string Text { get; set; }

        // The target node ID this choice leads to
        public string TargetId { get; set; }
    }
}