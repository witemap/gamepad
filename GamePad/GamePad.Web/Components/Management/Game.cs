using System.ComponentModel;

namespace GamePad.Web.Components.Management
{
    public class Game(string name, int minPlayers, int maxPlayers)
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string Name { get; init; } = name;
        public int MaxPlayers { get; init; } = maxPlayers;
        public int MinPlayers { get; init; } = minPlayers;
    }
}
